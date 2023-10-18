using System;
using System.Threading.Tasks;
using DocStore.Core.Entities;
using DocStore.Core.Services;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DocStore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSheetsController : Controller
    {
        private readonly ITimeSheetServices _timeSheetServices;

        public TimeSheetsController(
            ITimeSheetServices timeSheetServices
        )
        {
            _timeSheetServices = timeSheetServices ??
                                 throw new ArgumentNullException(nameof(timeSheetServices));
        }

        private string GetUserName()
        {
            return "system";
        }

        [HttpPost("v1/Store")]
        public async Task<StoreDocumentResponse<TimeSheet>> StoreDocument(
            [FromBody] StoreDocumentCommand<TimeSheet> command)
        {
            command.UserId = GetUserName();
            return await _timeSheetServices.StoreDocument(command);
        }

        [HttpPost("v1/GetList")]
        public async Task<GetDocumentsResponse<TimeSheet>> GetList(
            [FromBody] GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is null");
            query.UserId = GetUserName();
            return await _timeSheetServices.GetTimeSheets(query);
        }

        [HttpPost("v1/Get")]
        public GetDocumentResponse<TimeSheet> Get([FromBody] GetDocumentQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            Require.NotNullOrEmpty(query.Id, "Id is defined");

            query.UserId = GetUserName();
            return _timeSheetServices.GetTimeSheet(query);
        }

        [HttpPost("v1/Delete")]
        public async Task<AppResponse> Delete([FromBody] DeleteDocumentCommand command)
        {
            command.UserId = GetUserName();
            return await _timeSheetServices.DeleteTimeSheet(command);
        }
    }
}