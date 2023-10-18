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
    public class GroceryZenController : Controller
    {
        private readonly IMediator _mediator;

        public GroceryZenController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> ArchiveShoppingList([FromBody]ArchiveShoppingListRequest request)
        {
            var response = await _mediator.Send(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> ListShoppingLists()
        {
            var request = new ListShoppingListRequest();
            var response = await _mediator.Send(request);
            return Json(response);
        }

        public async Task<IActionResult> GetShoppingList(string Id)
        {
            var response = await _mediator.Send(new GetShoppingListRequest
            {
                Id = Id
            });

            return Json(response.ShoppingList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingList([FromBody] CreateShoppingListRequest request)
        {
            var response = await _mediator.Send(request);
            return Json(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> ListProductsForSearch([FromBody] WalmartProductSearchRequest request)
        {
            var response = await _mediator.Send(request);
            return Json(response);  
        }

        [HttpPost]
        public async Task<IActionResult> ListShoppingListItems([FromBody] ListShoppingListItemRequest request)
        {
            var response = await _mediator.Send(request);
            return Json(response);  
        }               

        [HttpPost]
        public async Task<IActionResult> CreateShoppingListItem([FromBody] CreateShoppingListItemRequest request) {
            var response = await _mediator.Send(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShoppingListItem([FromBody] DeleteShoppingListItemRequest request) {
            var response = await _mediator.Send(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteShoppingListItem([FromBody] CompleteShoppingListItemRequest request) {
            var response = await _mediator.Send(request);
            return Json(response);
        }
    }
}
