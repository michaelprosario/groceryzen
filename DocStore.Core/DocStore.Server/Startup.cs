using DocStore.Core.Entities;
using DocStore.Core.Interfaces;
using DocStore.Core.Services;
using DocStore.Infrastructure;
using DocStore.Infrastructure.Marten;
using DocumentStore.Enums;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using DocumentStore.Services;

using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Scrum.Core.Entities;
using Scrum.Core.Services;
using Scrum.Core.Validators;

using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using tusdotnet;
using tusdotnet.Models;
using tusdotnet.Models.Configuration;
using tusdotnet.Stores;

namespace DocStore.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                      .AddJwtBearer(options =>
                      {
                          options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
                          options.Audience = Configuration["Auth0:Audience"];

                          options.Events = new JwtBearerEvents
                          {
                              OnChallenge = context =>
                              {
                                  context.Response.OnStarting(async () =>
                                  {
                                  var errorResponse = new AppResponse
                                  {
                                      Code = ResponseCode.Unauthorized,
                                      Message = "You are not authorized!"
                                  };

                                  string jsonString = JsonSerializer.Serialize(errorResponse);
                                  await context.Response.WriteAsync(jsonString);                          
                                  });

                                  return Task.CompletedTask;
                              }
                          };
                      });
            services.AddAuthorization(o => { o.AddPolicy("team_focus_api", p => p.RequireAuthenticatedUser()); });
            services.Configure<AppSettings>(appSettingsSection);

            string connectionString = Configuration["ConnectionString"];
            if(string.IsNullOrEmpty(connectionString)){
                throw new ApplicationException("Connection string is null; Set using environment");
            }
            services.AddMarten(connectionString);
            services.AddControllersWithViews();
            services.AddSingleton<AppSettingsLoader>();

            // validators ...
            services.AddScoped(typeof(IValidator<Project>), typeof(ProjectValidator));
            services.AddScoped(typeof(IValidator<Sprint>), typeof(SprintValidator));
            services.AddScoped(typeof(IValidator<UserStory>), typeof(UserStoryValidator));

            services.AddScoped(typeof(IRepository<>), typeof(MartenRepository<>));
            // users ....
            services.AddScoped(typeof(IUserDataServices), typeof(MartenUserDataServices));
            services.AddScoped(typeof(IUserService), typeof(UsersService));

            // document services .....
            services.AddScoped(typeof(IDocumentsQueryRepository<>), typeof(MartenDocumentsQueryRepository<>));
            services.AddScoped(typeof(IDocumentsService<>), typeof(DocumentsService<>));

            // post services ...
            services.AddScoped(typeof(IPostsRepository), typeof(PostsRepository));
            services.AddScoped(typeof(IPostsService), typeof(PostsService));

            // page services ....
            services.AddScoped(typeof(IPagesRepository), typeof(PagesRepository));
            services.AddScoped(typeof(IPagesService), typeof(PagesService));

            // time sheet services .....
            services.AddScoped(typeof(ITimeSheetServices), typeof(TimeSheetServices));

            // scrum services ...
            services.AddScoped(typeof(IUserStoryQueryServices), typeof(UserStoryQueryServices));
            services.AddScoped(typeof(IProjectsService), typeof(ProjectsService));

            // generic entity service
            services.AddScoped(typeof(IEntityServices<>), typeof(EntityServices<>));

            // Drop down data ......
            services.AddScoped(typeof(IDropDownDataRepository), typeof(DropDownDataRepository));
            services.AddScoped(typeof(IGetDropDownDataService), typeof(GetDropDownDataService));

            // media files 
            services.AddScoped(typeof(IMediaFilesQueryRepository), typeof(MediaFilesQueryRepository));

            // user stories ...
            services.AddScoped(typeof(IUserStoryQueryRepository), typeof(UserStoryQueryRepository));

            services.AddSwaggerDocument();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            /*
            app.UseHealthChecks("/alive", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });
            app.UseHealthChecks("/ready", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("services")
            });
            */            
            

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

            var filePath = appSettings.MediaFilesPath;
            var tusDiskStore = new TusDiskStore(filePath, true);
            app.UseTus(httpContext => new DefaultTusConfiguration
            {
                Store = tusDiskStore,
                UrlPath = "/api/upload",
                Events = new Events
                {
                    OnFileCompleteAsync = async eventContext =>
                    {
                        var uploadService = new UploadService(filePath, new MediaRepository());

                        var file = await eventContext.GetFileAsync();
                        var fileMetaData = await file.GetMetadataAsync(eventContext.CancellationToken);
                        var fileNameMetadata = fileMetaData["file_name"];
                        var fileName = fileNameMetadata.GetString(Encoding.UTF8);

                        var addFileCommand = new AddFileCommand
                        {
                            FileId = eventContext.FileId, FileName = fileName
                        };
                        var uploadResponse = await uploadService.AddFile(addFileCommand);
                        if (uploadResponse.Code != ResponseCode.Success)
                            throw new ApplicationException(
                                "Startup.cs / error moving temp file to actual file name and directory");

                        var service = new ImageSizerService(new ImageServices());
                        var request = new CreateThumbnailRequest(fileName, filePath);
                        service.CreateThumbnail(request);
                    }
                }
            });
        }
    }
}