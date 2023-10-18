using System.Threading.Tasks;
using DocumentStore.Enums;
using DocumentStore.Helpers;
using DocumentStore.Interfaces;
using DocumentStore.Requests;
using DocumentStore.Responses;
using DocumentStore.Services;
using FluentValidation;
using Scrum.Core.Entities;

namespace Scrum.Core.Validators
{
    
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(r => r.CreatedBy).NotEmpty();
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.State).NotEmpty();
        }
    }

    public class SprintValidator : AbstractValidator<Sprint>
    {
        public SprintValidator()
        {
            RuleFor(r => r.CreatedBy).NotEmpty();
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.IterationPath).NotEmpty();
            RuleFor(r => r.DayCount).GreaterThan(0);                  
        }
    }

    public class UserStoryValidator : AbstractValidator<UserStory>
    {
        public UserStoryValidator()
        {
            RuleFor(r => r.CreatedBy).NotEmpty();
            RuleFor(r => r.Id).NotEmpty();            
            RuleFor(r => r.State).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Size).GreaterThan(0);
            RuleFor(r => r.Priority).GreaterThan(0);
            RuleFor(r => r.ProjectId).NotEmpty();                        
        }
    }

    public class ScrumTaskValidator : AbstractValidator<ScrumTask>
    {
        public ScrumTaskValidator()
        {
            RuleFor(r => r.CreatedBy).NotEmpty();
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.State).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
        }
    }
}
