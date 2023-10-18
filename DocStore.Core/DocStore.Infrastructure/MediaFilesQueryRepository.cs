using System.Linq;
using DocStore.Core.Services;
using DocumentStore.Entities;
using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using Marten;
using Marten.Pagination;

namespace DocStore.Infrastructure
{
    public class MediaFilesQueryRepository : IMediaFilesQueryRepository
    {
        private readonly IDocumentSession _session;

        public MediaFilesQueryRepository(IDocumentSession session)
        {
            Require.ObjectNotNull(session, "session should not be null");
            _session = session;
        }

        public GetDocumentResponse<MediaFile> GetMediaFile(GetMediaFileQuery query)
        {
            Require.ObjectNotNull(query, "query should not be null");
            Require.NotNullOrEmpty(query.FileName, "query.PermaLink should be defined");
            var data = _session.Query<MediaFile>()
                .FirstOrDefault(r => (r.FileName.Equals(query.FileName) || r.Id == query.Id) && !r.IsDeleted);
            if (data == null)
                return new GetDocumentResponse<MediaFile>
                {
                    Code = ResponseCode.NotFound,
                    Message = "MediaFile not found"
                };
            return new GetDocumentResponse<MediaFile>
            {
                Document = data
            };
        }

        public GetDocumentsResponse<MediaFile> GetMediaFiles(GetMediaFilesQuery query)
        {
            Require.ObjectNotNull(query, "query is required");
            var linqQuery = _session.Query<MediaFile>().Where(e => e.IsDeleted == false);

            if (!string.IsNullOrEmpty(query.FileName))
                linqQuery = linqQuery.Where(e => e.FileName.Contains(query.FileName));

            if (!string.IsNullOrEmpty(query.FileType))
                linqQuery = linqQuery.Where(e => e.FileType.Contains(query.FileType));

            var pagedList = linqQuery.ToPagedList(query.Page, query.Rows);
            var response = new GetDocumentsResponse<MediaFile>
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