using System;
using System.Threading.Tasks;
using DocStore.Core.Entities;
using DocStore.Core.Requests;
using DocStore.Core.Services;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocStore.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PagesController : Controller
    {
        private readonly IDocumentsService<Page> _documentsService;
        private readonly IPagesService _pagesService;

        public PagesController(
            IDocumentsService<Page> documentsService,
            IPagesService pagesService
        )
        {
            _documentsService = documentsService ?? throw new ArgumentNullException(nameof(documentsService));
            _pagesService = pagesService ?? throw new ArgumentNullException(nameof(pagesService));
        }

        private string GetUserName()
        {
            return "fixme";
        }

        [HttpPost("v1/Add")]
        public async Task<NewRecordResponse> Add([FromBody] AddDocumentCommand<Page> command)
        {
            Require.ObjectNotNull(command, "command should not be null");
            command.UserId = GetUserName();
            return await _documentsService.AddDocument(command);
        }

        [HttpPost("v1/Edit")]
        public async Task<AppResponse> EditAsync([FromBody] UpdateDocumentCommand<Page> command)
        {
            command.UserId = GetUserName();
            return await _documentsService.UpdateDocument(command);
        }

        [HttpPost("v1/Store")]
        public async Task<StoreDocumentResponse<Page>> StoreAsync([FromBody] StoreDocumentCommand<Page> command)
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
        public GetDocumentsResponse<Page> GetPagedList([FromBody] GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is null");
            query.UserId = GetUserName();
            var response = _pagesService.GetPages(query);
            response.AdditionalData = new { Tags = "foo,bar,blah".Split(',') };
            return response;
        }

        [HttpPost("v1/Get")]
        public async Task<GetDocumentResponse<Page>> GetAsync([FromBody] GetDocumentQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            query.UserId = GetUserName();
            return await _documentsService.GetDocument(query);
        }

        [HttpPost("v1/GetPage")]
        public GetDocumentResponse<Page> GetPage([FromBody] GetPostQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            Require.NotNullOrEmpty(query.PermaLink, "perma link is defined");
            Require.ObjectNotNull(_pagesService, "page service needs to be defined");
            query.UserId = GetUserName();
            return _pagesService.GetPage(query);
        }
    }
}