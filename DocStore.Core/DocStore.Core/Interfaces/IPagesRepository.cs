using DocStore.Core.Entities;
using DocStore.Core.Requests;
using DocumentStore.Requests;
using DocumentStore.Responses;

namespace DocStore.Core.Interfaces
{
    public interface IPagesRepository
    {
        GetDocumentResponse<Page> GetPage(GetPostQuery query);
        GetDocumentsResponse<Page> GetPages(GetDocumentsQuery query);
    }
}