using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Utilities;
using MediatR;
using System.Linq;

namespace App.Core.Handlers
{
    public class ListShoppingListItemHandler : RequestHandler<ListShoppingListItemRequest, ListShoppingListItemResponse>
    {
        IRepository<ShoppingListItem> _repository;
        public ListShoppingListItemHandler(IRepository<ShoppingListItem> repository)
        {
            _repository = repository;
        }
        protected override ListShoppingListItemResponse Handle(ListShoppingListItemRequest request)
        {
            var response = new ListShoppingListItemResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");

            var records = _repository.List();
            if(!string.IsNullOrEmpty(request.ShoppingListId))
            {
                records = records.Where(r => r.ShoppingListId == request.ShoppingListId).OrderBy(r => r.ProductName).ToList();
            }

            if(records == null)
            {
                response.Code = ResponseCode.Error;
                response.Message = "Error returning list";                
                return response;
            }

            response.Records = records;
            return response;
        }
    }
}
