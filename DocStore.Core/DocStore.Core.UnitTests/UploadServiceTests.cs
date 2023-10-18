using System.Threading.Tasks;
using DocumentStore.Enums;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using NSubstitute;
using NUnit.Framework;

namespace DocStore.Core.UnitTests
{
    public class UploadServiceTests
    {
        [SetUp]
        public void SetupStuff()
        {
        }

        [Test]
        public async Task UploadService__AddImage__HappyCaseAsync()
        {
            // arrange 
            var filesPath = @"c:\dev\someCoolFolder";
            var fileName = "TestFile.png";
            var fullPath = filesPath + @"\" + fileName;
            var mediaRepository = Substitute.For<IMediaRepository>();
            mediaRepository.DirectoryExists(filesPath).Returns(true);
            mediaRepository.FileExists(fullPath).Returns(true);

            var service = new UploadService(filesPath, mediaRepository);
            var command = new AddFileCommand { FileName = fileName, FileId = "someFileId" };

            // act
            var response = await service.AddFile(command);

            // assert 
            Assert.NotNull(response);

            // file should exist in storage
            var fileExistsInMetaData = service.FileExistsInMetaData(fullPath);
            Assert.IsTrue(fileExistsInMetaData);
        }

        [Test]
        public async Task UploadService__AddImage__HandleDirectoryNotFound()
        {
            // arrange 
            var filesPath = @"c:\dev\someCoolFolder";
            var fileName = "TestFile.png";
            var fullPath = filesPath + @"\" + fileName;
            var mediaRepository = Substitute.For<IMediaRepository>();
            mediaRepository.DirectoryExists(filesPath).Returns(false);
            mediaRepository.FileExists(fullPath).Returns(true);

            var service = new UploadService(filesPath, mediaRepository);
            var command = new AddFileCommand { FileName = fileName, FileId = "someFileId" };
            var response = new AppResponse();

            // act
            response = await service.AddFile(command);

            // assert 
            Assert.NotNull(response);
            Assert.IsTrue(response.Code == ResponseCode.BadRequest);
        }
    }
}