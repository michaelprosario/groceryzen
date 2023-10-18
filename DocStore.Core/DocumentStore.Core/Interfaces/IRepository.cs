using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentStore.Requests;
using DocumentStore.Responses;

namespace DocumentStore.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        T GetById(string id);
        List<T> List();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool RecordExists(string id);
        Task<GetDocumentsResponse<T>> GetPagedList(GetDocumentsQuery query);
    }
}