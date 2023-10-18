using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentStore.Helpers;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Responses;
using Marten;
using Marten.Pagination;

namespace DocStore.Infrastructure.Marten
{
    public class MartenRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly IDocumentSession _session;

        public MartenRepository(IDocumentSession session)
        {
            Require.ObjectNotNull(session, "session should not be null");
            _session = session;
        }

        public T Add(T entity)
        {
            Require.ObjectNotNull(entity, "entity should not be null");
            _session.Store(entity);
            _session.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            Require.ObjectNotNull(entity, "entity should not be null");
            _session.Delete(entity);
            _session.SaveChanges();
        }

        public T GetById(string id)
        {
            Require.NotNullOrEmpty(id, "id should not be null");
            T entityToReturn;
            entityToReturn = _session.Query<T>().Single(e => e.Id.Equals(id));
            return entityToReturn;
        }

        public List<T> List()
        {
            var returnList = _session.Query<T>().ToList();
            return returnList;
        }

        public bool RecordExists(string id)
        {
            Require.NotNullOrEmpty(id, "id should not be null");
            var count = _session.Query<T>().Count(e => e.Id.Equals(id));
            return count > 0;
        }

        public async Task<GetDocumentsResponse<T>> GetPagedList(GetDocumentsQuery query)
        {
            var pagedList = await _session.Query<T>().Where(r => !r.IsDeleted).ToPagedListAsync(query.Page, query.Rows);
            var response = new GetDocumentsResponse<T>
            {
                TotalItemCount = pagedList.TotalItemCount,
                PageCount = pagedList.PageCount,
                IsFirstPage = pagedList.IsFirstPage,
                IsLastPage = pagedList.IsLastPage,
                HasNextPage = pagedList.HasNextPage,
                HasPreviousPage = pagedList.HasPreviousPage,
                FirstItemOnPage = pagedList.FirstItemOnPage,
                LastItemOnPage = pagedList.LastItemOnPage,
                Documents = pagedList.ToList()
            };

            return response;
        }

        public void Update(T entity)
        {
            Require.ObjectNotNull(entity, "entity should not be null");
            _session.Store(entity);
            _session.SaveChanges();
        }
    }
}