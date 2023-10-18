using DocumentStore.Requests;
using FluentValidation;

namespace DocumentStore.Validators
{
    public class GetDocumentQueryValidator : AbstractValidator<GetDocumentQuery>
    {
        public GetDocumentQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}