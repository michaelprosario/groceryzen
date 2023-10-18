using System.Linq;
using System.Threading.Tasks;
using DocumentStore.Helpers;
using DocumentStore.Responses;
using Marten;
using Scrum.Core.Entities;
using Scrum.Core.Services;
using Marten.Pagination;

namespace DocStore.Infrastructure.Marten
{
    public class UserStoryQueryRepository : IUserStoryQueryRepository
    {
        private readonly IDocumentSession _session;

        public UserStoryQueryRepository(IDocumentSession session)
        {
            Require.ObjectNotNull(session, "session should not be null");
            _session = session;
        }

        public async Task<GetDocumentsResponse<UserStory>> GetUserStories(GetUserStoriesQuery query)
        {
            Require.ObjectNotNull(query, "query is required");
            var linqQuery = _session.Query<UserStory>().Where(e => e.IsDeleted == false);

            if (!string.IsNullOrEmpty(query.Keyword))
                linqQuery = linqQuery.Where(e =>
                  e.Name.Contains(query.Keyword) ||
                  e.Description.Contains(query.Keyword) ||
                  e.DoneConditions.Contains(query.Keyword));

            if (!string.IsNullOrEmpty(query.Tag)) linqQuery = linqQuery.Where(e => e.Tags.Contains(query.Tag));

            if (!string.IsNullOrEmpty(query.ProjectId)) linqQuery = linqQuery.Where(e => e.ProjectId.Equals(query.ProjectId));

            if (!string.IsNullOrEmpty(query.IterationPath)) linqQuery = linqQuery.Where(e => e.IterationPath.Equals(query.IterationPath));

            linqQuery = linqQuery.OrderBy(x => x.Name);
            var pagedList = await linqQuery.ToPagedListAsync(query.Page, query.Rows);

            var response = new GetDocumentsResponse<UserStory>
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