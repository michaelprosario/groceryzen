using App.Core.Entities;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace App.Core.Test
{
    [TestClass]
    public class ShoppingListTests
    {
        ServiceProvider _serviceProvider;
        IMediator _mediator;
        [TestInitialize]
        public void Intialize()
        {
            _serviceProvider = ServiceProviderUtility.GetServiceProvider();
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            var shoppingListRepository = _serviceProvider.GetService<IRepository<ShoppingList>>();
            var shoppingListItemRepository = _serviceProvider.GetService<IRepository<ShoppingListItem>>();
            TestDataUtilities testDataUtilities = new TestDataUtilities(shoppingListRepository, shoppingListItemRepository);
            testDataUtilities.CleanUpShoppingListTestRecords();
        }

        [TestMethod]
        public async Task CreateShoppingList__HappyCase()
        {
            // arrange
            CreateShoppingListRequest request = new CreateShoppingListRequest
            {
                Name = "Test record",
                UserId = TestConstants.TestUser
            };

            // Act
            CreateShoppingListResponse response = await _mediator.Send(request);

            // Assert
            Assert.IsTrue(response != null, "response is defined");
        }

        [TestMethod]
        public async Task CreateShoppingList__PassNoName()
        {
            // arrange
            var request = new CreateShoppingListRequest
            {
                Name = ""
            };

            // Act
            CreateShoppingListResponse response = await _mediator.Send(request);

            Assert.IsTrue(response.ValidationErrors.Count > 0);
        }

        [TestMethod]
        public async Task GetShoppingList__HappyCase()
        {
            // arrange
            string shoppingListId = await createShoppingList();

            // Act
            GetShoppingListResponse getShoppingListResponse = await _mediator.Send(new GetShoppingListRequest
            {
                Id = shoppingListId
            });

            // Assert
            Assert.IsTrue(getShoppingListResponse != null, "response is defined");            
        }

        [TestMethod]
        public async Task ListShoppingList__HappyCase()
        {
            // arrange
            for(int i=0; i<10; i++) { 
                string shoppingListId = await createShoppingList();
            }

            // Act
            var response = await _mediator.Send(new ListShoppingListRequest());
            
            // Assert
            Assert.IsTrue(response != null, "response is defined");
            Assert.IsTrue(response.Records.Count >= 10, "we should have 10 records");
        }
        
        [TestMethod]
        public async Task GetShoppingList__RecordNotFound()
        {
            // arrange

            // Act
            GetShoppingListResponse getShoppingListResponse = await _mediator.Send(new GetShoppingListRequest
            {
                Id = "badRecordID"
            });

            // Assert
            Assert.IsTrue(getShoppingListResponse != null, "response is defined");
            Assert.IsTrue(getShoppingListResponse.Code == Enums.ResponseCode.NotFound);
        }

        public async Task DeleteShoppingList__HappyCase()
        {
            string shoppingListId = await createShoppingList();

            DeleteShoppingListRequest deleteShoppingListRequest = new DeleteShoppingListRequest
            {
                Id = shoppingListId
            };

            // Act
            var deleteResponse = await _mediator.Send(deleteShoppingListRequest);

            // Assert
            Assert.IsTrue(deleteResponse != null, "response is defined");
            GetShoppingListResponse getShoppingListResponse = await getShoppingListById(shoppingListId);
            Assert.IsTrue(getShoppingListResponse.Code == Enums.ResponseCode.NotFound, "record should not exist");
        }

        private async Task<GetShoppingListResponse> getShoppingListById(string shoppingListId)
        {
            return await _mediator.Send(new GetShoppingListRequest
            {
                Id = shoppingListId
            });
        }

        private async Task<string> createShoppingList()
        {
            CreateShoppingListRequest request = new CreateShoppingListRequest
            {
                Name = "Test record",
                UserId = TestConstants.TestUser
            };

            CreateShoppingListResponse response = await _mediator.Send(request);
            string shoppingListId = response.Id;
            return shoppingListId;
        }


    }
}
