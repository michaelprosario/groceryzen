using System.Linq;
using DocStore.Core.Entities;
using DocStore.Core.Interfaces;
using DocStore.Core.Requests;
using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using Marten;
using Marten.Pagination;

namespace DocStore.Infrastructure.Marten
{
    public class PagesRepository : IPagesRepository
    {
        private readonly IDocumentSession _session;

        public PagesRepository(IDocumentSession session)
        {
            Require.ObjectNotNull(session, "session should not be null");
            _session = session;
        }

        public GetDocumentResponse<Page> GetPage(GetPostQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            Require.NotNullOrEmpty(query.PermaLink, "query.PermaLink should be defined");
            var data = _session.Query<Page>().FirstOrDefault(r => r.PermaLink.Equals(query.PermaLink) && !r.IsDeleted);
            if (data == null)
                return new GetDocumentResponse<Page>
                {
                    Code = ResponseCode.NotFound,
                    Message = "Post not found"
                };
            return new GetDocumentResponse<Page>
            {
                Document = data
            };
        }

        public GetDocumentsResponse<Page> GetPages(GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is required");
            var linqQuery = _session.Query<Page>().Where(e => e.IsDeleted == false);

            if (!string.IsNullOrEmpty(query.Keyword))
                linqQuery = linqQuery.Where(e => e.Content.Contains(query.Keyword));

            if (!string.IsNullOrEmpty(query.Tag)) linqQuery = linqQuery.Where(e => e.Tags.Contains(query.Tag));

            var pagedList = linqQuery.ToPagedList(query.Page, query.Rows);
            var response = new GetDocumentsResponse<Page>
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
    }
}