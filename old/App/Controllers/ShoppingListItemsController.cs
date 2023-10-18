using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core;
using App.Core.Entities;
using App.Core.Requests;
using App.Core.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ShoppingListItemsController : Controller
    {
        private readonly IMediator _mediator;

        public ShoppingListItemsController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> ListProductsForSearch(string queryString)
        {
            var request = new WalmartProductSearchRequest();
            request.Query = queryString;           
            var response = await _mediator.Send(request);
            return Json(response);  
        }

        [HttpGet]
        public async Task<IActionResult> ListShoppingListItems(string Id)
        {
            var request = new ListShoppingListItemRequest();
            request.ShoppingListId = Id;
            var response = await _mediator.Send(request);
            return Json(response);  
        }               

        public async Task<IActionResult> CreateShoppingListItem(CreateShoppingListItemRequest request) {
            request.Qty = 1;
            request.Price = request.UnitPrice;
            var response = await _mediator.Send(request);
            return Json(response);
        }
    }
}