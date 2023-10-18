using System;
using System.Threading.Tasks;
using DocStore.Core.Entities;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Services;
using NSubstitute;
using NUnit.Framework;

namespace DocStore.Core.UnitTests
{
    public class Tests
    {
        private IDocumentsQueryRepository<Post> _documentsQueryRepository;
        private IRepository<Post> _repository;

        [SetUp]
        public void Setup()
        {
            _documentsQueryRepository = Substitute.For<IDocumentsQueryRepository<Post>>();
            _repository = Substitute.For<IRepository<Post>>();
        }

        [Test]
        public async Task DocumentsService__Add__HappyCaseAsync()
        {
            // arrange
            var command = GetAddDocumentCommand();

            var returnDocument = command.Document;
            returnDocument.Id = "newId";
            _repository.Add(command.Document).Returns(returnDocument);

            var service = new DocumentsService<Post>(_repository);

            // act
            var newRecordResponse = await service.AddDocument(command);
            var response = newRecordResponse;

            // assert
            Assert.NotNull(response);
            Assert.AreEqual(returnDocument.Id, response.RecordId);
        }

        [Test]
        public void DocumentsService__Update__HappyCase()
        {
            // arrange
            var command = GetUpdateDocumentCommand();
            _repository.Update(command.Document);
            var service = new DocumentsService<Post>(_repository);

            // act
            service.UpdateDocument(command);

            // assert
            _repository.Received().Update(command.Document);
        }

        [Test]
        public void DocumentsService__Store__AddCaseAsync()
        {
            // arrange
            var command = GetStoreDocumentCommand();
            _repository.RecordExists(command.Document.Id).Returns(false);
            _repository.Add(command.Document).Returns(command.Document);

            var service = new DocumentsService<Post>(_repository);

            // act
            service.StoreDocument(command);

            // assert
            _repository.Received().Add(command.Document);
        }

        [Test]
        public void DocumentsService__Store__UpdateCase()
        {
            // arrange
            var command = GetStoreDocumentCommand();
            _repository.RecordExists(command.Document.Id).Returns(true);
            _repository.Update(command.Document);
            var service = new DocumentsService<Post>(_repository);

            // act
            service.StoreDocument(command);

            // assert
            _repository.Received().Update(command.Document);
        }

        [Test]
        public void DocumentsService__PopulateAddDocumentCommand()
        {
            // arrange
            var command = GetAddDocumentCommand();
            var service = new DocumentsService<Post>(_repository);

            // act
            var docAfter = service.PopulateNewDocumentFields(command.Document, "mrosario");

            // assert
            Assert.NotNull(docAfter);
            Assert.IsNotEmpty(docAfter.CreatedBy);
            Assert.IsNotEmpty(docAfter.Id);
        }

        private AddDocumentCommand<Post> GetAddDocumentCommand()
        {
            var command = new AddDocumentCommand<Post>
            {
                Document = new Post
                {
                    Content = "Foo",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "mrosario",
                    HtmlContent = "foo", Id = "PostId",
                    PermaLink = "Foo",
                    Name = "Foo"
                },
                UserId = "TestUser"
            };

            return command;
        }

        private StoreDocumentCommand<Post> GetStoreDocumentCommand()
        {
            var command = new StoreDocumentCommand<Post>
            {
                Document = new Post
                {
                    Content = "Foo",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "mrosario",
                    HtmlContent = "foo", Id = "PostId",
                    PermaLink = "Foo",
                    Name = "Foo"
                },
                UserId = "TestUser"
            };

            return command;
        }

        private UpdateDocumentCommand<Post> GetUpdateDocumentCommand()
        {
            var command = new UpdateDocumentCommand<Post>
            {
                Document = new Post
                {
                    Content = "Foo",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "mrosario",
                    HtmlContent = "foo", Id = "PostId",
                    PermaLink = "Foo",
                    Name = "Foo"
                },
                UserId = "TestUser"
            };


            return command;
        }
    }
}