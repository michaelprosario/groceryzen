using System.IO;
using System.Threading.Tasks;
using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Validators;

namespace DocumentStore.Services
{
    public class UploadService
    {
        private readonly string filesPath;
        private readonly IMediaRepository mediaRepository;

        public UploadService(string filesPath, IMediaRepository mediaRepository)
        {
            Require.NotNullOrEmpty(filesPath, "filesPath is required");
            Require.ObjectNotNull(mediaRepository, "mediaRepository is required");
            this.filesPath = filesPath;
            this.mediaRepository = mediaRepository;
        }

        public async Task<AppResponse> AddFile(AddFileCommand command)
        {
            var response = new AppResponse();
            Require.ObjectNotNull(command, "command is required");

            var validationResult = await new AddFileCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                response.Code = ResponseCode.BadRequest;
                return response;
            }

            var filePathExists = mediaRepository.DirectoryExists(filesPath);
            if (!filePathExists)
            {
                response.Message = "UploadService / file path does not exist";
                response.Code = ResponseCode.BadRequest;
                return response;
            }

            var sourcePath = filesPath + Path.DirectorySeparatorChar + command.FileId;
            var sourcePathExists = mediaRepository.FileExists(sourcePath);
            if (!sourcePathExists)
            {
                response.Message = "UploadService / source path does not exist";
                response.Code = ResponseCode.BadRequest;
                return response;
            }

            var targetPath = filesPath + Path.DirectorySeparatorChar + command.FileName;
            mediaRepository.MoveFile(sourcePath, targetPath);
            mediaRepository.ClearTempFiles(filesPath, command.FileId);

            return response;
        }

        public bool FileExistsInMetaData(string fullPath)
        {
            Require.NotNullOrEmpty(fullPath, "fullPath is required");
            return mediaRepository.FileExists(fullPath);
        }
    }
}