using DocStore.Core.Requests;
using FluentValidation;

namespace DocStore.Core.Validators
{
    public class GetPostQueryValidator : AbstractValidator<GetPostQuery>
    {
        public GetPostQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.PermaLink).NotNull().NotEmpty();
        }
    }
}