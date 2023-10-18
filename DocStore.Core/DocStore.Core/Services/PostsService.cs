using System;
using System.Collections.Generic;
using DocStore.Core.Entities;
using DocStore.Core.Interfaces;
using DocStore.Core.Requests;
using DocStore.Core.Responses;
using DocStore.Core.Validators;
using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Validators;

namespace DocStore.Core.Services
{
    public interface IPostsService
    {
        GetDocumentResponse<Post> GetPost(GetPostQuery query);
        GetDocumentsResponse<Post> GetPosts(GetDocumentsQuery query);
        HomePageResponse GetHomePageData(GetDocumentsQuery query);
    }

    public class PostsService : IPostsService
    {
        private readonly IDropDownDataRepository dropDownDataRepository;
        private readonly IPostsRepository postsRepository;

        public PostsService(IPostsRepository postsRepository, IDropDownDataRepository dropDownDataRepository)
        {
            if (postsRepository is null) throw new ArgumentNullException(nameof(postsRepository));
            if (dropDownDataRepository is null) throw new ArgumentNullException(nameof(dropDownDataRepository));

            this.postsRepository = postsRepository;
            this.dropDownDataRepository = dropDownDataRepository;
        }

        public GetDocumentResponse<Post> GetPost(GetPostQuery query)
        {
            Require.ObjectNotNull(query, "query is required");
            var validationResult = new GetPostQueryValidator().Validate(query);
            if (!validationResult.IsValid)
                return new GetDocumentResponse<Post>
                {
                    Code = ResponseCode.BadRequest,
                    ValidationErrors = validationResult.Errors
                };

            return postsRepository.GetPost(query);
        }

        public GetDocumentsResponse<Post> GetPosts(GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is required");

            var validationResult = new GetDocumentsQueryValidator().Validate(query);
            if (!validationResult.IsValid)
            {
                var response = new GetDocumentsResponse<Post>
                {
                    Code = ResponseCode.BadRequest,
                    ValidationErrors = validationResult.Errors
                };
                return response;
            }

            return postsRepository.GetPosts(query);
        }

        public HomePageResponse GetHomePageData(GetDocumentsQuery query)
        {
            Require.ObjectNotNull(query, "query is required");

            var validationResult = new GetDocumentsQueryValidator().Validate(query);
            if (!validationResult.IsValid)
            {
                var response = new HomePageResponse
                {
                    Code = ResponseCode.BadRequest,
                    ValidationErrors = validationResult.Errors
                };
                return response;
            }

            var homePageResponse = new HomePageResponse();

            var posts = postsRepository.GetPosts(query);
            if (posts == null || posts.Documents.Count == 0)
                homePageResponse.Posts = new List<Post>();
            else
                homePageResponse.Posts = posts.Documents;

            homePageResponse.DropDownDataItems = dropDownDataRepository.GetDropDownItems();
            homePageResponse.Pages = new List<Page>();

            return homePageResponse;
        }
    }
}