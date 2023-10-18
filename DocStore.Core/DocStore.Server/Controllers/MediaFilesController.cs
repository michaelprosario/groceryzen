using System;
using System.IO;
using System.Threading.Tasks;
using DocStore.Core.Entities;
using DocStore.Core.Services;
using DocumentStore.Entities;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace DocStore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaFilesController : Controller
    {
        public readonly IConfiguration _configuration;
        private readonly IDocumentsService<MediaFile> _documentsService;
        private readonly IMediaFilesQueryRepository _mediaFilesQueryRepository;

        public MediaFilesController(
            IDocumentsService<MediaFile> documentsService,
            IMediaFilesQueryRepository mediaFilesQueryRepository,
            IConfiguration configuration
        )
        {
            _documentsService = documentsService ?? throw new ArgumentNullException(nameof(documentsService));
            _mediaFilesQueryRepository = mediaFilesQueryRepository ??
                                         throw new ArgumentNullException(nameof(mediaFilesQueryRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private string GetUserName()
        {
            return "fixme";
        }

        [Authorize]
        [HttpPost("v1/Add")]
        public async Task<NewRecordResponse> Add([FromBody] AddDocumentCommand<MediaFile> command)
        {
            Require.ObjectNotNull(command, "command should not be null");
            command.UserId = GetUserName();
            return await _documentsService.AddDocument(command);
        }

        [Authorize]
        [HttpPost("v1/Edit")]
        public async Task<AppResponse> Edit([FromBody] UpdateDocumentCommand<MediaFile> command)
        {
            command.UserId = GetUserName();
            return await _documentsService.UpdateDocument(command);
        }

        [Authorize]
        [HttpPost("v1/Store")]
        public async Task<StoreDocumentResponse<MediaFile>> Store([FromBody] StoreDocumentCommand<MediaFile> command)
        {
            command.UserId = GetUserName();
            return await _documentsService.StoreDocument(command);
        }

        [Authorize]
        [HttpPost("v1/Delete")]
        public async Task<AppResponse> Delete([FromBody] DeleteDocumentCommand command)
        {
            command.UserId = GetUserName();
            return await _documentsService.DeleteDocument(command);
        }
        
        [HttpPost("v1/GetPagedList")]
        public GetDocumentsResponse<MediaFile> GetPagedList([FromBody] GetMediaFilesQuery query)
        {
            Require.ObjectNotNull(query, "query is null");
            query.UserId = GetUserName();
            var response = _mediaFilesQueryRepository.GetMediaFiles(query);
            response.AdditionalData = new { Tags = "foo,bar,blah".Split(',') };
            return response;
        }

        [HttpPost("v1/GetMediaFile")]
        public GetDocumentResponse<MediaFile> GetMediaFile([FromBody] GetMediaFileQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            Require.NotNullOrEmpty(query.Id, "Id is defined");
            Require.NotNullOrEmpty(query.FileName, "FileName is defined");

            query.UserId = GetUserName();
            return _mediaFilesQueryRepository.GetMediaFile(query);
        }

        [HttpGet("v1/File/{fileName}")]
        public async Task<ActionResult> DownloadFile(string fileName)
        {
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var baseMediaPath = appSettings.MediaFilesPath;
            if (string.IsNullOrEmpty(baseMediaPath)) throw new ApplicationException("baseMediaPath is empty");

            var filePath = baseMediaPath + Path.DirectorySeparatorChar + fileName;

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType)) contentType = "application/octet-stream";

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }

        [HttpPost("v1/Get")]
        public async Task<GetDocumentResponse<MediaFile>> Get([FromBody] GetDocumentQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            query.UserId = GetUserName();
            return await _documentsService.GetDocument(query);
        }
    }
}