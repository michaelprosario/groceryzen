using System.Linq;
using DocStore.Core.Entities;
using DocumentStore.Helpers;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Responses;
using Marten;
using Marten.Pagination;

namespace DocStore.Infrastructure.Marten
{
    public class MartenDocumentsQueryRepository<T> : IDocumentsQueryRepository<T> where T : IEntity
    {
        private readonly IDocumentSession _session;

        public MartenDocumentsQueryRepository(IDocumentSession session)
        {
            Require.ObjectNotNull(session, "session should not be null");
            _session = session;
        }

        public IQueryable<T> GetDocumentsByCollection(string collection)
        {
            return _session
                .Query<T>()
                .Where(e => e.IsDeleted == false);
        }

        public GetDocumentsResponse<T> GetDocuments(GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is required");
            var pagedList = _session.Query<T>().Where(e => e.IsDeleted == false).ToPagedList(query.Page, query.Rows);
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

        public string GetSchemaValidationData(string collection)
        {
            Require.NotNullOrEmpty(collection, "collection should not be null");
            var validationData = _session.Query<SchemaValidationData>()
                .FirstOrDefault(e => e.CollectionName.Equals(collection));
            if (validationData == null)
                return "";
            return validationData.Schema;
        }

        public bool SchemaValidationDataExists(string collection)
        {
            Require.NotNullOrEmpty(collection, "collection should not be null");
            var count = _session.Query<SchemaValidationData>().Count(e => e.CollectionName.Equals(collection));
            return count > 0;
        }
    }
}