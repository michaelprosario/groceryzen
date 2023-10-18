using DocumentStore.Requests;
using FluentValidation;

namespace DocumentStore.Validators
{
    public class GetMediaFileQueryValidator : AbstractValidator<GetMediaFileQuery>
    {
        public GetMediaFileQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}