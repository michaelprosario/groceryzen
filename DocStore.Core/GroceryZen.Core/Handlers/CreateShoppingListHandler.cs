using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;

namespace App.Core.Handlers
{
    public class CreateShoppingListHandler 
    {
        IRepository<ShoppingList> _shoppingListRepository;
        public CreateShoppingListHandler(IRepository<ShoppingList> shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        protected override CreateShoppingListResponse Handle(CreateShoppingListRequest request)
        {
            var response = new CreateShoppingListResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");
            var validationErrors = RequestValidator.Validate<CreateShoppingListRequest>(request);
            
            if(validationErrors.Count > 0) {
                response.ValidationErrors = validationErrors;
            }else{
                ShoppingList record = new ShoppingList
                {
                    Name = request.Name,
                    IsActive = true
                };

                HandlerUtilities.TimeStampRecord(record, request.UserId);
                var returnRecord = _shoppingListRepository.Add(record);
                response.Id = returnRecord.Id;
            }
            
            return response;
        }
    }
}
