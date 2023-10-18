using System;
using DocStore.Core.Entities;
using DocStore.Core.Interfaces;
using DocStore.Core.Requests;
using DocStore.Core.Validators;
using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Validators;

namespace DocStore.Core.Services
{
    public interface IPagesService
    {
        GetDocumentResponse<Page> GetPage(GetPostQuery query);
        GetDocumentsResponse<Page> GetPages(GetDocumentsQuery query);
    }

    public class PagesService : IPagesService
    {
        private readonly IPagesRepository pagesRepository;

        public PagesService(IPagesRepository pagesRepository)
        {
            if (pagesRepository is null) throw new ArgumentNullException(nameof(pagesRepository));

            this.pagesRepository = pagesRepository;
        }

        public GetDocumentResponse<Page> GetPage(GetPostQuery query)
        {
            Require.ObjectNotNull(query, "query is required");
            var validationResult = new GetPostQueryValidator().Validate(query);
            if (!validationResult.IsValid)
                return new GetDocumentResponse<Page>
                {
                    Code = ResponseCode.BadRequest,
                    ValidationErrors = validationResult.Errors
                };

            return pagesRepository.GetPage(query);
        }

        public GetDocumentsResponse<Page> GetPages(GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is required");

            var validationResult = new GetDocumentsQueryValidator().Validate(query);
            if (!validationResult.IsValid)
            {
                var response = new GetDocumentsResponse<Page>
                {
                    Code = ResponseCode.BadRequest,
                    ValidationErrors = validationResult.Errors
                };
                return response;
            }

            return pagesRepository.GetPages(query);
        }
    }
}