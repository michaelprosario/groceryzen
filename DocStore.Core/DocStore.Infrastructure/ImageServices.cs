using System.IO;
using DocStore.Core.Services;
using DocumentStore.Helpers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace DocStore.Infrastructure
{
    public class ImageServices : IImageServices
    {
        public void CreateBoxThumbnail(string fileName, string mediaDirectory)
        {
            Require.NotNullOrEmpty(fileName, "fileName should not be empty");
            Require.NotNullOrEmpty(mediaDirectory, "mediaDirectory should not be empty");

            var sourcePath = mediaDirectory + Path.DirectorySeparatorChar + fileName;
            var targetPath = mediaDirectory + Path.DirectorySeparatorChar + "thumbnail_" + fileName;

            using (var image = Image.Load(sourcePath))
            {
                image.Mutate(x => x.Resize(250, 0));
                image.Save(targetPath);
            }
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}