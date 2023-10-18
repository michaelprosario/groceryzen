using NUnit.Framework;
using System.IO;
using System;
using System.Reflection;
using DocStore.Core.Services;
using DocStore.Infrastructure;

namespace DocStore.Integration.Tests
{
    public class ImageSizerServiceTests
    {
        public static string GetTestsPath() { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file", string.Empty); }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ImageSizerService__CreateBoxThumbnail__HappyCase()
        {
            // arrange
            string testFilePath = @"C:\dev\DocStore.Core\DocStore.Integration.Tests\testFiles";
            string fileName = "beachHouse.jpg";
            string targetFile = testFilePath + Path.DirectorySeparatorChar + "thumbnail_" + fileName;

            var imageService = new ImageServices();
            var service = new ImageSizerService(imageService);

            var request = new CreateThumbnailRequest();
            request.FileName = fileName;
            request.MediaDirectory = testFilePath;

            // act
            service.CreateThumbnail(request);

            // assert
            Assert.IsTrue(File.Exists(targetFile)); 

        }
    }
}