using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using System.Threading.Tasks;
using FluentValidation;

namespace DocumentStore.Services
{
    public interface IEntityServices<T> where T : IEntity
    {
        Task<AppResponse> DeleteDocument(DeleteDocumentCommand command);
        GetDocumentResponse<T> GetDocument(GetDocumentQuery query);
        Task<GetDocumentsResponse<T>> GetDocuments(GetDocumentsQuery query);
        Task<StoreDocumentResponse<T>> StoreDocument(StoreDocumentCommand<T> command);
    }

    public class EntityServices<T> : IEntityServices<T> where T : IEntity
    {
        private readonly IDocumentsService<T> _documentsService;
        private readonly IRepository<T> _commandRepository;
        private readonly IValidator<T> validator;

        public EntityServices(
            IDocumentsService<T> documentsService,
            IRepository<T> commandRepo,
            IValidator<T> validator
        )
        {
            Require.ObjectNotNull(documentsService, "documents service is required");
            Require.ObjectNotNull(commandRepo, "commandRepo is required");
            _documentsService = documentsService;
            _commandRepository = commandRepo;
            this.validator = validator ?? throw new System.ArgumentNullException(nameof(validator));
        }

        public async Task<StoreDocumentResponse<T>> StoreDocument(StoreDocumentCommand<T> command)
        {
            Require.ObjectNotNull(command, "command is not null");

            var validationResults = await this.validator.ValidateAsync(command.Document);
            if (validationResults.Errors.Count > 0)
                return new StoreDocumentResponse<T>
                {
                    Code = ResponseCode.BadRequest,
                    ValidationErrors = validationResults.Errors
                };

            var recordExists = _commandRepository.RecordExists(command.Document.Id);
            if (recordExists)
                _commandRepository.Update(command.Document);
            else
                _commandRepository.Add(command.Document);

            return new StoreDocumentResponse<T>
            {
                Document = command.Document,
                Message = recordExists ? "updated record" : "added record"
            };
        }

        public GetDocumentResponse<T> GetDocument(GetDocumentQuery query)
        {
            Require.ObjectNotNull(query, "query is not null");
            var record = _commandRepository.GetById(query.Id);
            if (record == null)
                return new GetDocumentResponse<T>
                {
                    Code = ResponseCode.NotFound,
                    Message = "Record not found"
                };

            return new GetDocumentResponse<T>
            {
                Document = record
            };
        }

        public async Task<AppResponse> DeleteDocument(DeleteDocumentCommand command)
        {
            Require.ObjectNotNull(command, "command is required");
            return await _documentsService.DeleteDocument(command);
        }

        public async Task<GetDocumentsResponse<T>> GetDocuments(GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is not null");
            return await _commandRepository.GetPagedList(query);
        }
    }
}