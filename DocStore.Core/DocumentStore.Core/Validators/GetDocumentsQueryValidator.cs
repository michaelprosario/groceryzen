using DocumentStore.Requests;
using FluentValidation;

namespace DocumentStore.Validators
{
    public class GetDocumentsQueryValidator : AbstractValidator<GetDocumentsQuery>
    {
        public GetDocumentsQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.First).GreaterThan(0);
            RuleFor(x => x.Rows).GreaterThan(0);
            RuleFor(x => x.Page).GreaterThan(0);
        }
    }
}