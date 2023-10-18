using System;
using DocStore.Core.Services;
using DocumentStore.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DocStore.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostsService _postsService;

        public HomeController(
            IPostsService postsService,
            ILogger<HomeController> logger
        )
        {
            _postsService = postsService ?? throw new ArgumentNullException(nameof(postsService));
            _logger = logger;
        }

        private string GetUserName()
        {
            return "fixme";
        }

        public IActionResult Index()
        {
            var query = new GetDocumentsQuery
            {
                First = 1,
                UserId = GetUserName()
            };

            var response = _postsService.GetHomePageData(query);

            return View(response);
        }
    }
}