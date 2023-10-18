using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scrum.Core.Entities;
using Scrum.Core.Services;
using System;
using System.Threading.Tasks;

namespace DocStore.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserStoriesController : Controller
    {
        private readonly IEntityServices<UserStory> _entityServices;
        private readonly IUserStoryQueryServices _userStoryQueryServices;

        public UserStoriesController(
                IEntityServices<UserStory> entityServices,
                IUserStoryQueryServices userStoryQueryServices
            )
        {
            _entityServices = entityServices ??
                                 throw new ArgumentNullException(nameof(entityServices));
            this._userStoryQueryServices = userStoryQueryServices ?? throw new ArgumentNullException(nameof(userStoryQueryServices));
        }

        private string GetUserName()
        {
            return "system";
        }

        [HttpPost("v1/Store")]
        public async Task<StoreDocumentResponse<UserStory>> StoreDocument([FromBody] StoreDocumentCommand<UserStory> command)
        {
            command.UserId = GetUserName();
            return await _entityServices.StoreDocument(command);
        }

        [HttpPost("v1/GetList")]
        public async Task<GetDocumentsResponse<UserStory>> GetList([FromBody] GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is null");
            query.UserId = GetUserName();
            return await _entityServices.GetDocuments(query);
        }

        [HttpPost("v1/Get")]
        public GetDocumentResponse<UserStory> Get([FromBody] GetDocumentQuery query)
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

        [HttpPost("v1/GetUserStories")]
        public async Task<GetDocumentsResponse<UserStory>> GetUserStories([FromBody] GetUserStoriesQuery query)
        {
            Require.ObjectNotNull(query, "query is null");
            query.UserId = GetUserName();
            return await _userStoryQueryServices.GetUserStories(query);
        }
    }
}