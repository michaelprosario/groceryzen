using DocStore.Core.Entities;
using DocStore.Core.Requests;
using DocumentStore.Requests;
using DocumentStore.Responses;

namespace DocStore.Core.Interfaces
{
    public interface IPostsRepository
    {
        GetDocumentResponse<Post> GetPost(GetPostQuery query);
        GetDocumentsResponse<Post> GetPosts(GetDocumentsQuery query);
    }
}