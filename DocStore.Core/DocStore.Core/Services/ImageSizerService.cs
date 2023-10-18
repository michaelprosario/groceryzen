using System.IO;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;

namespace DocStore.Core.Services
{
    public class CreateThumbnailRequest : Request
    {
        public CreateThumbnailRequest(string fileName, string mediaDirectory)
        {
            FileName = fileName;
            MediaDirectory = mediaDirectory;
        }

        public CreateThumbnailRequest()
        {
        }

        public string FileName { get; set; }
        public string MediaDirectory { get; set; }
    }

    public interface IImageServices
    {
        void CreateBoxThumbnail(string fileName, string mediaDirectory);
        bool FileExists(string filePath);
    }

    public class ImageSizerService
    {
        private readonly IImageServices _imageServices;

        public ImageSizerService(IImageServices imageServices)
        {
            Require.ObjectNotNull(imageServices, "imageServices is required");
            _imageServices = imageServices;
        }

        public AppResponse CreateThumbnail(CreateThumbnailRequest request)
        {
            Require.ObjectNotNull(request, "request is required");
            Require.NotNullOrEmpty(request.FileName, "request.fileName is required");
            Require.NotNullOrEmpty(request.MediaDirectory, "request.MediaDirectory is required");

            var response = new AppResponse();

            var fullPath = request.MediaDirectory + Path.DirectorySeparatorChar + "thumbnail_" + request.FileName;
            if (!_imageServices.FileExists(fullPath))
                _imageServices.CreateBoxThumbnail(request.FileName, request.MediaDirectory);

            return response;
        }
    }
}