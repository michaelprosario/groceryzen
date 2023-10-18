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
    public class ShoppingListController : Controller
    {
        private readonly IMediator _mediator;

        public ShoppingListController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IActionResult> Index()
        {
            var request = new ListShoppingListRequest();
            var response = await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> ListShoppingListItems(string Id)
        {
            ListShoppingListItemRequest request = new ListShoppingListItemRequest();
            request.ShoppingListId = Id;           
            var response = await _mediator.Send(request);
            return Json(response);
        }

        public async Task<IActionResult> Archive(string Id)
        {
            var response = await _mediator.Send(new ArchiveShoppingListRequest
            {
                Id = Id
            });

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(string Id)
        {
            var response = await _mediator.Send(new GetShoppingListRequest
            {
                Id = Id
            });

            return View(response.ShoppingList);
        }

        public ActionResult Create()
        {
            var model = new ShoppingList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(String Name)
        {
            CreateShoppingListRequest createShoppingListRequest = new CreateShoppingListRequest
            {
                Name = Name
            };

            CreateShoppingListResponse response = null;
            try
            {
                response = await _mediator.Send(createShoppingListRequest);
            }
            catch (RequestValidationException rve)
            {
                foreach(var validationException in rve.ValidationErrors)
                {
                    ModelState.AddModelError(validationException.PropertyName, validationException.ErrorMessage);
                }

                return View(new ShoppingList
                {
                    Name = Name
                });
            }

            return RedirectToAction("Index");
        }
    }
}
