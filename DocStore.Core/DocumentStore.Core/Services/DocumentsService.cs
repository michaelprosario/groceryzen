using System;
using System.Threading.Tasks;
using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Validators;

namespace DocumentStore.Services
{
    public interface IDocumentsService<T> where T : IEntity
    {
        Task<NewRecordResponse> AddDocument(AddDocumentCommand<T> command);
        Task<AppResponse> DeleteDocument(DeleteDocumentCommand command);
        Task<GetDocumentResponse<T>> GetDocument(GetDocumentQuery query);
        Task<AppResponse> UpdateDocument(UpdateDocumentCommand<T> command);
        Task<StoreDocumentResponse<T>> StoreDocument(StoreDocumentCommand<T> command);
        Task<GetDocumentsResponse<T>> GetPagedList(GetDocumentsQuery query);
    }

    public class DocumentsService<T> : IDocumentsService<T> where T : IEntity
    {
        private readonly IRepository<T> _repository;

        public DocumentsService(
            IRepository<T> repository
        )
        {
            Require.ObjectNotNull(repository, "repository should be defined");

            _repository = repository;
        }

        public async Task<NewRecordResponse> AddDocument(AddDocumentCommand<T> command)
        {
            Require.ObjectNotNull(command, "command is required");
            var response = new NewRecordResponse
            {
                Code = ResponseCode.Success
            };

            var validationResult = await new AddDocumentCommandValidator<T>().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                response.Code = ResponseCode.BadRequest;
                return response;
            }

            PopulateNewDocumentFields(command.Document, command.UserId);

            var doc = _repository.Add(command.Document);
            response.RecordId = doc.Id;

            return response;
        }

        public async Task<StoreDocumentResponse<T>> StoreDocument(StoreDocumentCommand<T> command)
        {
            Require.ObjectNotNull(command, "command is defined");
            var response = new StoreDocumentResponse<T>();

            var validationResult = await new StoreDocumentCommandValidator<T>().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                response.Code = ResponseCode.BadRequest;
                return response;
            }

            var recordExists = _repository.RecordExists(command.Document.Id);
            string currentRecordId;
            if (recordExists)
            {
                currentRecordId = command.Document.Id;
                PopulateDocumentForUpdate(command.Document, command.UserId);
                _repository.Update(command.Document);
            }
            else
            {
                PopulateNewDocumentFields(command.Document, command.UserId);
                var newDocument = _repository.Add(command.Document);
                currentRecordId = newDocument.Id;
            }

            var documentToReturn = _repository.GetById(currentRecordId);
            response.Document = documentToReturn;
            return response;
        }

        public Task<GetDocumentsResponse<T>> GetPagedList(GetDocumentsQuery query)
        {
            return _repository.GetPagedList(query);
        }

        public async Task<AppResponse> UpdateDocument(UpdateDocumentCommand<T> command)
        {
            Require.ObjectNotNull(command, "Command is required");

            var response = new AppResponse
            {
                Code = ResponseCode.Success
            };

            var validationResult = await new UpdateDocumentCommandValidator<T>().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                response.Code = ResponseCode.BadRequest;
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            PopulateDocumentForUpdate(command.Document, command.UserId);
            _repository.Update(command.Document);

            return response;
        }

        public async Task<GetDocumentResponse<T>> GetDocument(GetDocumentQuery query)
        {
            Require.ObjectNotNull(query, "query is required");
            var validationResult = await new GetDocumentQueryValidator().ValidateAsync(query);
            if (!validationResult.IsValid)
            {
                var response = new GetDocumentResponse<T>
                {
                    Code = ResponseCode.BadRequest,
                    ValidationErrors = validationResult.Errors
                };
                return response;
            }

            var doc = _repository.GetById(query.Id);
            return new GetDocumentResponse<T>
            {
                Document = doc
            };
        }

        public async Task<AppResponse> DeleteDocument(DeleteDocumentCommand command)
        {
            Require.ObjectNotNull(command, "Command is required");
            var response = new AppResponse
            {
                Code = ResponseCode.Success
            };

            var validationResult = await new DeleteDocumentCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                response.Code = ResponseCode.BadRequest;
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = _repository.GetById(command.Id);
            if (record == null)
            {
                response.Code = ResponseCode.NotFound;
                return response;
            }

            record.DeletedAt = DateTime.Now;
            record.DeletedBy = command.UserId;
            record.IsDeleted = true;
            _repository.Update(record);

            return response;
        }

        public IEntity PopulateNewDocumentFields(IEntity document, string userId)
        {
            Require.ObjectNotNull(document, "document is required");
            document.CreatedAt = DateTime.Now;
            document.CreatedBy = userId;
            if (string.IsNullOrEmpty(document.Id)) document.Id = Guid.NewGuid().ToString();

            return document;
        }

        private void PopulateDocumentForUpdate(IEntity document, string userId)
        {
            document.UpdatedAt = DateTime.Now;
            document.UpdatedBy = userId;
        }

        public GetDocumentsResponse<T> GetAllDocuments()
        {
            var response = new GetDocumentsResponse<T>
            {
                Documents = _repository.List()
            };
            return response;
        }
    }
}