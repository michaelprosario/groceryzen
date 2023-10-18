using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;

namespace App.Core.Handlers
{
    public class DeleteShoppingListItemHandler : RequestHandler<DeleteShoppingListItemRequest, VoidResponse>
    {
        IRepository<ShoppingListItem> _repository;
        public DeleteShoppingListItemHandler(IRepository<ShoppingListItem> repository)
        {
            _repository = repository;
        }

        protected override VoidResponse Handle(DeleteShoppingListItemRequest request)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");
            RequestValidator.ValidateAndThrowException<DeleteShoppingListItemRequest>(request);

            var returnRecord = _repository.GetById(request.Id);
            if(returnRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                response.Message = "Record not found";                
                return response;
            }

            _repository.Delete(returnRecord);
            
            return response;
        }
    }
}
