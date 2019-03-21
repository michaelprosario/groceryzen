using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Utilities;
using MediatR;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace App.Core.Handlers
{
    public class CreateShoppingListItemHandler : RequestHandler<CreateShoppingListItemRequest, CreateShoppingListItemResponse>
    {
        IRepository<ShoppingListItem> _repository;
        public CreateShoppingListItemHandler(IRepository<ShoppingListItem> repository)
        {
            _repository = repository;
        }
        
        protected override CreateShoppingListItemResponse Handle(CreateShoppingListItemRequest request)
        {
            var response = new CreateShoppingListItemResponse
            {
                Code = ResponseCode.Success
            };
                        
            Require.ObjectNotNull(request, "Request is null.");
            
            var validationErrors = RequestValidator.Validate<CreateShoppingListItemRequest>(request);
            if(validationErrors.Count > 0){
                response.ValidationErrors = validationErrors;
                return response;
            }
        
            ShoppingListItem record = new ShoppingListItem();
			
			record.ShoppingListId = request.ShoppingListId;
			record.ProductName = request.ProductName;
			record.ProductCategory = request.ProductCategory;
			record.UnitPrice = request.UnitPrice;
			record.Qty = request.Qty;
			record.Price = request.Price;
			record.Completed = request.Completed;
			record.CreatedBy = request.CreatedBy;
			record.UpdatedBy = request.UpdatedBy;
			record.CreatedAt = request.CreatedAt;
			record.UpdatedAt = request.UpdatedAt;
            
            HandlerUtilities.TimeStampRecord(record, request.UserId);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;
            return response;
        }
    }
}
