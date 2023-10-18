using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;

namespace App.Core.Handlers
{
    public class CompleteShoppingListItemHandler : RequestHandler<CompleteShoppingListItemRequest, VoidResponse>
    {
        IRepository<ShoppingListItem> _repository;
        public CompleteShoppingListItemHandler(IRepository<ShoppingListItem> repository)
        {
            _repository = repository;
        }

        protected override VoidResponse Handle(CompleteShoppingListItemRequest request)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");
            RequestValidator.ValidateAndThrowException<CompleteShoppingListItemRequest>(request);

            var returnRecord = _repository.GetById(request.ShoppingListItemId);
            if(returnRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                response.Message = "Record not found";                
                return response;
            }

            returnRecord.Completed = !returnRecord.Completed;

            _repository.Update(returnRecord);

            return response;
        }
    }
}
