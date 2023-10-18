using System;
using System.Threading.Tasks;
using DocStore.Core.Entities;
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
    public class DocumentsController : Controller
    {
        private readonly IDocumentsService<Doc> _documentsService;

        public DocumentsController(IDocumentsService<Doc> documentsService)
        {
            _documentsService = documentsService ?? throw new ArgumentNullException(nameof(documentsService));
        }

        private string GetUserName()
        {
            return "fixme";
        }

        [HttpPost("v1/Add")]
        public async Task<NewRecordResponse> Add([FromBody] AddDocumentCommand<Doc> command)
        {
            Require.ObjectNotNull(command, "command should not be null");
            command.UserId = GetUserName();
            return await _documentsService.AddDocument(command);
        }

        [HttpPost("v1/Edit")]
        public async Task<AppResponse> Edit([FromBody] UpdateDocumentCommand<Doc> command)
        {
            command.UserId = GetUserName();
            return await _documentsService.UpdateDocument(command);
        }

        [HttpPost("v1/Store")]
        public async Task<StoreDocumentResponse<Doc>> Store([FromBody] StoreDocumentCommand<Doc> command)
        {
            command.UserId = GetUserName();
            return await _documentsService.StoreDocument(command);
        }

        [HttpPost("v1/Delete")]
        public async Task<AppResponse> Delete([FromBody] DeleteDocumentCommand command)
        {
            command.UserId = GetUserName();
            return await _documentsService.DeleteDocument(command);
        }

        [HttpPost("v1/GetPagedList")]
        public async Task<GetDocumentsResponse<Doc>> GetPagedList([FromBody] GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is null");
            query.UserId = GetUserName();
            return await _documentsService.GetPagedList(query);
        }

        [HttpPost("v1/Get")]
        public async Task<GetDocumentResponse<Doc>> Get([FromBody] GetDocumentQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            query.UserId = GetUserName();
            return await _documentsService.GetDocument(query);
        }
    }
}