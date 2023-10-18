using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;

namespace App.Core.Handlers
{
    public class GetShoppingListHandler
    {
        IRepository<ShoppingList> _shoppingListRepository;
        public GetShoppingListHandler(IRepository<ShoppingList> shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        protected override GetShoppingListResponse Handle(GetShoppingListRequest request)
        {
            var response = new GetShoppingListResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");
            RequestValidator.ValidateAndThrowException<GetShoppingListRequest>(request);

            var returnRecord = _shoppingListRepository.GetById(request.Id);
            if(returnRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                response.Message = "Record not found";                
                return response;
            }

            response.ShoppingList = returnRecord;
            return response;
        }
    }
}
