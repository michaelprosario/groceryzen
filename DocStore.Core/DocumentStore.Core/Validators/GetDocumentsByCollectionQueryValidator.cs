using DocumentStore.Requests;
using FluentValidation;

namespace DocumentStore.Validators
{
    public class GetDocumentsByCollectionQueryValidator : AbstractValidator<GetDocumentsByCollection>
    {
        public GetDocumentsByCollectionQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Collection).NotNull().NotEmpty();
        }
    }
}