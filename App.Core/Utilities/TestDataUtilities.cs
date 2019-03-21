using App.Core.Entities;
using App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App.Core.Utilities
{
    public class TestDataUtilities
    {
        public TestDataUtilities(
            IRepository<ShoppingList> shoppingListRepository,
            IRepository<ShoppingListItem> shoppingListItemRepository
        )
        {
            _shoppingListRepository = shoppingListRepository;
            _shoppingListItemRepository = shoppingListItemRepository;
        }

        public void CleanUpShoppingListTestRecords()
        {
            // get list of shopping list records marked with test user
            var testShoppingLists = _shoppingListRepository.List().Where(r =>  r.CreatedBy == null || r.CreatedBy.Equals(TESTUSER)).ToList();

            foreach(var shoppingList in testShoppingLists)
            {
                var shoppingListItems = _shoppingListItemRepository.List().Where(sli => sli.ShoppingListId == shoppingList.Id).ToList();
                foreach(var shoppingListItem in shoppingListItems)
                {
                    _shoppingListItemRepository.Delete(shoppingListItem);
                }

                _shoppingListRepository.Delete(shoppingList);
            }            
        }

        private IRepository<ShoppingList> _shoppingListRepository { get; }
        public IRepository<ShoppingListItem> _shoppingListItemRepository { get; }

        public string TESTUSER = "testuser";
        private readonly IServiceProvider _serviceProvider;
    }
}
