using System.Linq;
using DocumentStore.Requests;
using DocumentStore.Responses;

namespace DocumentStore.Interfaces
{
    public interface IDocumentsQueryRepository<T>
    {
        IQueryable<T> GetDocumentsByCollection(string collection);
        GetDocumentsResponse<T> GetDocuments(GetDocumentsQuery query);
        bool SchemaValidationDataExists(string collection);
        string GetSchemaValidationData(string collection);
    }
}