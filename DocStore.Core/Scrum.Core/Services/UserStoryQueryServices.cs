using System.Threading.Tasks;
using DocumentStore.Responses;
using FluentValidation;
using Scrum.Core.Entities;

namespace Scrum.Core.Services
{

  public class GetUserStoriesQueryValidator : AbstractValidator<GetUserStoriesQuery>
  {
    public GetUserStoriesQueryValidator()
    {
      RuleFor(r => r.ProjectId).NotEmpty();
    }
  }

  public interface IUserStoryQueryServices
  {
    Task<GetDocumentsResponse<UserStory>> GetUserStories(GetUserStoriesQuery query);
  }

  public interface IUserStoryQueryRepository
  {
    Task<GetDocumentsResponse<UserStory>> GetUserStories(GetUserStoriesQuery query);
  }

  public class UserStoryQueryServices : IUserStoryQueryServices
  {
    private readonly IUserStoryQueryRepository queryRepository;

    public UserStoryQueryServices(IUserStoryQueryRepository queryRepository)
    {
      this.queryRepository = queryRepository ?? throw new System.ArgumentNullException(nameof(queryRepository));
    }

    public async Task<GetDocumentsResponse<UserStory>> GetUserStories(GetUserStoriesQuery query)
    {
      var validator = new GetUserStoriesQueryValidator();
      var validationResults = validator.Validate(query);
      if(validationResults.Errors.Count > 0){
        return new GetDocumentsResponse<UserStory>{
          Message = "Validation errors",
          Code = DocumentStore.Enums.ResponseCode.BadRequest,
          ValidationErrors = validationResults.Errors
        };
      }

      return await queryRepository.GetUserStories(query);
    }
  }

}