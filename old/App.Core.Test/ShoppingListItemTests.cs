using App.Core.Entities;
using App.Core.Handlers;
using App.Infrastructure;
using App.Core.Interfaces;
using App.Core.SharedKernel;
using App.Core.Requests;
using App.Core.Utilities;
using System;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;


namespace App.Core.Test
{
    [TestClass]
    public class ShoppingListItemTests
    {
        ServiceProvider _serviceProvider;
        IMediator _mediator;
        [TestInitialize]
        public void Intialize()
        {
            _serviceProvider = ServiceProviderUtility.GetServiceProvider();
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        public void CleanUp()
        {
            var shoppingListRepository = _serviceProvider.GetService<IRepository<ShoppingList>>();
            var shoppingListItemRepository = _serviceProvider.GetService<IRepository<ShoppingListItem>>();
            TestDataUtilities testDataUtilities = new TestDataUtilities(shoppingListRepository, shoppingListItemRepository);
            testDataUtilities.CleanUpShoppingListTestRecords();
        }

        [TestMethod]
        public async Task CreateShoppingListWithOneItem()
        {
            // arrange
            CreateShoppingListRequest request = new CreateShoppingListRequest
            {
                Name = "Test record",
                UserId = TestConstants.TestUser
            };
            CreateShoppingListResponse response = await _mediator.Send(request);

            // Act

            var createShoppingListItemResponse = await _mediator.Send(new CreateShoppingListItemRequest
            {
                Completed = false,
                Price = 3,
                ProductCategory = "Pet",
                ProductName = "Cat",
                ShoppingListId = response.Id,
                Qty = 3,
                UnitPrice = 5,
                UserId = "mrosario"
            });

            // Assert
            var getRecordResponse = await _mediator.Send(new GetShoppingListItemRequest
            {
                Id = createShoppingListItemResponse.Id,
                UserId = "mrosario"
            });

            Assert.IsTrue(getRecordResponse.Code == Enums.ResponseCode.Success);
        }

        [TestMethod]
        public async Task ListShoppingListItems__HappyCase()
        {
            // arrange
            CreateShoppingListRequest request = new CreateShoppingListRequest
            {
                Name = "Test record",
                UserId = TestConstants.TestUser
            };
            CreateShoppingListResponse shoppingListResponse = await _mediator.Send(request);

            var createShoppingListItemResponse = await _mediator.Send(new CreateShoppingListItemRequest
            {
                Completed = false,
                Price = 3,
                ProductCategory = "Pet",
                ProductName = "Cat",
                ShoppingListId = shoppingListResponse.Id,
                Qty = 3,
                UnitPrice = 5,
                UserId = "mrosario"
            });

            // Act
            var shoppingListItemsResponse = await _mediator.Send(new ListShoppingListItemRequest { ShoppingListId = shoppingListResponse.Id });

            // Assert
            Assert.IsTrue(shoppingListItemsResponse.Records.Count == 1);
        }




    }
}
