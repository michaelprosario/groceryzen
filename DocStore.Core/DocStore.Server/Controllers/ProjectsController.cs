using System;
using System.Threading.Tasks;
using DocStore.Core.Entities;
using DocStore.Core.Services;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using Scrum.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Scrum.Core.Services;
using System;
using Microsoft.AspNetCore.Authorization;

namespace DocStore.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IEntityServices<Project> _entityServices;
        private readonly IProjectsService _projectsService;

        public ProjectsController(
            IEntityServices<Project> entityServices,
            IProjectsService projectsService
        )
        {
            _projectsService = projectsService ?? throw new ArgumentNullException(nameof(projectsService));
            _entityServices = entityServices ?? throw new ArgumentNullException(nameof(entityServices));
        }

        private string GetUserName()
        {
            return "system";
        }

        [HttpPost("v1/Store")]
        public async Task<StoreDocumentResponse<Project>> StoreDocument(
            [FromBody] StoreDocumentCommand<Project> command)
        {
            command.UserId = GetUserName();
            return await _entityServices.StoreDocument(command);
        }

        [HttpPost("v1/GetList")]
        public async Task<GetDocumentsResponse<Project>> GetList(
            [FromBody] GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is null");
            query.UserId = GetUserName();
            return await _entityServices.GetDocuments(query);
        }

        [HttpPost("v1/Get")]
        public GetDocumentResponse<Project> Get([FromBody] GetDocumentQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            Require.NotNullOrEmpty(query.Id, "Id is defined");

            query.UserId = GetUserName();
            return _entityServices.GetDocument(query);
        }

        [HttpPost("v1/Delete")]
        public async Task<AppResponse> Delete([FromBody] DeleteDocumentCommand command)
        {
            command.UserId = GetUserName();
            return await _entityServices.DeleteDocument(command);
        }

        [HttpPost("v1/GetNewProject")]
        public Project GetNewProject()
        {
            return _projectsService.GetNewProject();
        }        
    }
}