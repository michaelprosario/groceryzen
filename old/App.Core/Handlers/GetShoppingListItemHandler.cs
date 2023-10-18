using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Utilities;
using MediatR;

namespace App.Core.Handlers
{
    public class GetShoppingListItemHandler : RequestHandler<GetShoppingListItemRequest, GetShoppingListItemResponse>
    {
        IRepository<ShoppingListItem> _repository;
        public GetShoppingListItemHandler(IRepository<ShoppingListItem> repository)
        {
            _repository = repository;
        }
        protected override GetShoppingListItemResponse Handle(GetShoppingListItemRequest request)
        {
            var response = new GetShoppingListItemResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");
            RequestValidator.ValidateAndThrowException<GetShoppingListItemRequest>(request);

            var returnRecord = _repository.GetById(request.Id);
            if(returnRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                response.Message = "Record not found";                
                return response;
            }

            response.ShoppingListItem = returnRecord;
            return response;
        }
    }
}
