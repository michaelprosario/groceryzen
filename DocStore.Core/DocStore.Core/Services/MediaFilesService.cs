using System;
using DocumentStore.Entities;
using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Validators;

namespace DocStore.Core.Services
{
    public interface IMediaFilesQueryRepository
    {
        GetDocumentResponse<MediaFile> GetMediaFile(GetMediaFileQuery query);
        GetDocumentsResponse<MediaFile> GetMediaFiles(GetMediaFilesQuery query);
    }

    public class MediaFilesService : IMediaFilesQueryRepository
    {
        private readonly IMediaFilesQueryRepository mediaFilesRepository;

        public MediaFilesService(IMediaFilesQueryRepository mediaFilesRepository)
        {
            if (mediaFilesRepository is null) throw new ArgumentNullException(nameof(mediaFilesRepository));

            this.mediaFilesRepository = mediaFilesRepository;
        }

        public GetDocumentResponse<MediaFile> GetMediaFile(GetMediaFileQuery query)
        {
            Require.ObjectNotNull(query, "query is required");
            var validationResult = new GetMediaFileQueryValidator().Validate(query);
            if (!validationResult.IsValid)
                return new GetDocumentResponse<MediaFile>
                {
                    Code = ResponseCode.BadRequest,
                    ValidationErrors = validationResult.Errors
                };

            return mediaFilesRepository.GetMediaFile(query);
        }

        public GetDocumentsResponse<MediaFile> GetMediaFiles(GetMediaFilesQuery query)
        {
            Require.ObjectNotNull(query, "query is required");
            return mediaFilesRepository.GetMediaFiles(query);
        }
    }
}