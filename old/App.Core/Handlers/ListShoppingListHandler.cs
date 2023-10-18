using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;
using System.Linq;

namespace App.Core.Handlers
{
    public class ListShoppingListHandler : RequestHandler<ListShoppingListRequest, ListShoppingListResponse>
    {
        IRepository<ShoppingList> _shoppingListRepository;
        public ListShoppingListHandler(IRepository<ShoppingList> shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        protected override ListShoppingListResponse Handle(ListShoppingListRequest request)
        {
            var response = new ListShoppingListResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");

            var records = _shoppingListRepository.List();
            if(records == null)
            {
                response.Code = ResponseCode.Error;
                response.Message = "Error returning list";                
                return response;
            }

            response.Records = records.Where(r => r.IsActive).ToList();
            return response;
        }
    }
}
