using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;

namespace App.Core.Handlers
{
    public class DeleteShoppingListHandler
    {
        IRepository<ShoppingList> _shoppingListRepository;
        public DeleteShoppingListHandler(IRepository<ShoppingList> shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        protected override VoidResponse Handle(DeleteShoppingListRequest request)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");
            RequestValidator.ValidateAndThrowException<DeleteShoppingListRequest>(request);

            var returnRecord = _shoppingListRepository.GetById(request.Id);
            if(returnRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                response.Message = "Record not found";                
                return response;
            }

            _shoppingListRepository.Delete(returnRecord);
            
            return response;
        }
    }
}
