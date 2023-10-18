using System.Threading.Tasks;
using DocStore.Core.Entities;
using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using FluentValidation;

namespace DocStore.Core.Services
{
    public class TimeSheetValidator : AbstractValidator<TimeSheet>
    {
        public TimeSheetValidator()
        {
            RuleFor(r => r.CreatedBy).NotEmpty();
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.WeekEnding).NotEmpty();
        }
    }

    public interface ITimeSheetServices
    {
        Task<StoreDocumentResponse<TimeSheet>> StoreDocument(StoreDocumentCommand<TimeSheet> command);
        GetDocumentResponse<TimeSheet> GetTimeSheet(GetDocumentQuery query);
        Task<AppResponse> DeleteTimeSheet(DeleteDocumentCommand command);
        Task<GetDocumentsResponse<TimeSheet>> GetTimeSheets(GetDocumentsQuery query);
    }

    public class TimeSheetServices : ITimeSheetServices
    {
        private readonly IDocumentsService<TimeSheet> _documentsService;
        private readonly IRepository<TimeSheet> _timeSheetsCommandRepository;

        public TimeSheetServices(
            IDocumentsService<TimeSheet> documentsService,
            IRepository<TimeSheet> timeSheetsCommandRepository
        )
        {
            Require.ObjectNotNull(documentsService, "documents service is required");
            Require.ObjectNotNull(timeSheetsCommandRepository, "TimeSheetCommandRepository is required");
            _documentsService = documentsService;
            _timeSheetsCommandRepository = timeSheetsCommandRepository;
        }

        public async Task<StoreDocumentResponse<TimeSheet>> StoreDocument(StoreDocumentCommand<TimeSheet> command)
        {
            Require.ObjectNotNull(command, "command is not null");

            var validator = new TimeSheetValidator();
            var validationResults = await validator.ValidateAsync(command.Document);
            if (validationResults.Errors.Count > 0)
                return new StoreDocumentResponse<TimeSheet>
                {
                    Code = ResponseCode.BadRequest,
                    ValidationErrors = validationResults.Errors
                };

            var recordExists = _timeSheetsCommandRepository.RecordExists(command.Document.Id);
            if (recordExists)
                _timeSheetsCommandRepository.Update(command.Document);
            else
                _timeSheetsCommandRepository.Add(command.Document);

            return new StoreDocumentResponse<TimeSheet>
            {
                Document = command.Document
            };
        }

        public GetDocumentResponse<TimeSheet> GetTimeSheet(GetDocumentQuery query)
        {
            Require.ObjectNotNull(query, "query is not null");
            var record = _timeSheetsCommandRepository.GetById(query.Id);
            if (record == null)
                return new GetDocumentResponse<TimeSheet>
                {
                    Code = ResponseCode.NotFound, Message = "Record not found"
                };

            return new GetDocumentResponse<TimeSheet>
            {
                Document = record
            };
        }

        public async Task<AppResponse> DeleteTimeSheet(DeleteDocumentCommand command)
        {
            Require.ObjectNotNull(command, "command is required");
            return await _documentsService.DeleteDocument(command);
        }

        public async Task<GetDocumentsResponse<TimeSheet>> GetTimeSheets(GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is not null");
            return await _timeSheetsCommandRepository.GetPagedList(query);
        }
    }
}