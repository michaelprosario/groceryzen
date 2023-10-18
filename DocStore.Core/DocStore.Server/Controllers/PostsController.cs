using System;
using System.Threading.Tasks;
using DocStore.Core.Entities;
using DocStore.Core.Requests;
using DocStore.Core.Services;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocStore.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IDocumentsService<Post> _documentsService;
        private readonly IGetDropDownDataService _dropDataService;
        private readonly IPostsService _postsService;

        public PostsController(
            IDocumentsService<Post> documentsService,
            IPostsService postsService,
            IGetDropDownDataService dropDownDataService
        )
        {
            _documentsService = documentsService ?? throw new ArgumentNullException(nameof(documentsService));
            _postsService = postsService ?? throw new ArgumentNullException(nameof(postsService));
            _dropDataService = dropDownDataService ?? throw new ArgumentNullException(nameof(dropDownDataService));
        }

        private string GetUserName()
        {
            return "fixme";
        }

        [HttpPost("v1/Add")]
        public async Task<NewRecordResponse> Add([FromBody] AddDocumentCommand<Post> command)
        {
            Require.ObjectNotNull(command, "command should not be null");
            command.UserId = GetUserName();
            return await _documentsService.AddDocument(command);
        }

        [HttpPost("v1/Edit")]
        public async Task<AppResponse> EditAsync([FromBody] UpdateDocumentCommand<Post> command)
        {
            command.UserId = GetUserName();
            return await _documentsService.UpdateDocument(command);
        }

        [HttpPost("v1/Store")]
        public async Task<StoreDocumentResponse<Post>> StoreAsync([FromBody] StoreDocumentCommand<Post> command)
        {
            command.UserId = GetUserName();
            return await _documentsService.StoreDocument(command);
        }

        [HttpPost("v1/Delete")]
        public async Task<AppResponse> DeleteAsync([FromBody] DeleteDocumentCommand command)
        {
            command.UserId = GetUserName();
            return await _documentsService.DeleteDocument(command);
        }

        [HttpPost("v1/GetPagedList")]
        public GetDocumentsResponse<Post> GetPagedList([FromBody] GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is null");
            query.UserId = GetUserName();
            var response = _postsService.GetPosts(query);
            response.AdditionalData = _dropDataService.GetDropDownItems();
            return response;
        }

        [HttpPost("v1/Search")]
        public IActionResult Search([FromBody] GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is null");
            query.UserId = GetUserName();
            var response = _postsService.GetPosts(query);
            ViewBag.Posts = response.Documents;
            
            return View(response); 
        }        

        [HttpPost("v1/Get")]
        public async Task<GetDocumentResponse<Post>> GetAsync([FromBody] GetDocumentQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            query.UserId = GetUserName();
            return await _documentsService.GetDocument(query);
        }

        [HttpPost("v1/GetPost")]
        public GetDocumentResponse<Post> GetPost([FromBody] GetPostQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            Require.NotNullOrEmpty(query.PermaLink, "perma link is defined");
            Require.ObjectNotNull(_postsService, "post service needs to be defined");
            query.UserId = GetUserName();
            return _postsService.GetPost(query);
        }
    }
}