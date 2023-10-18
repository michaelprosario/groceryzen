using System;
using DocStore.Core.Entities;
using DocStore.Core.Requests;
using DocStore.Core.Services;
using DocumentStore.Requests;
using DocumentStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocStore.Server.Controllers
{
    [ApiController]
    [Route("content")]
    public class ContentController : Controller
    {
        private readonly IDocumentsService<Post> _documentsService;
        private readonly IGetDropDownDataService _dropDataService;
        private readonly IPostsService _postsService;

        public ContentController(
            IDocumentsService<Post> documentsService,
            IPostsService postsService,
            IGetDropDownDataService dropDownDataService
        )
        {
            _documentsService = documentsService ?? throw new ArgumentNullException(nameof(documentsService));
            _postsService = postsService ?? throw new ArgumentNullException(nameof(postsService));
            _dropDataService = dropDownDataService ?? throw new ArgumentNullException(nameof(dropDownDataService));
        }

        [HttpGet("post/{link}")]
        public IActionResult ViewPost(string link)
        {
            var getPostResponse = _postsService.GetPost(new GetPostQuery
            {
                PermaLink = link,
                UserId = "viewer"
            });
            if (getPostResponse == null) throw new ApplicationException("getPostResponse is null");

            var getHomePageResponse = _postsService.GetHomePageData(new GetDocumentsQuery
            {
                First = 1,
                UserId = "viewer"
            });
            ViewBag.Posts = getHomePageResponse.Posts;

            return View(getPostResponse);
        }
    }
}