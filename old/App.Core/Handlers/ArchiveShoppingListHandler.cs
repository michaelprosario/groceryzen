using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;

namespace App.Core.Handlers
{
    public class ArchiveShoppingListHandler : RequestHandler<ArchiveShoppingListRequest, VoidResponse>
    {
        IRepository<ShoppingList> _shoppingListRepository;
        public ArchiveShoppingListHandler(IRepository<ShoppingList> shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        protected override VoidResponse Handle(ArchiveShoppingListRequest request)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");
            RequestValidator.ValidateAndThrowException<ArchiveShoppingListRequest>(request);

            var returnRecord = _shoppingListRepository.GetById(request.Id);
            if(returnRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                response.Message = "Record not found";                
                return response;
            }

            returnRecord.IsActive = false;
            _shoppingListRepository.Update(returnRecord);
            
            return response;
        }
    }
}
