using DocumentStore.Interfaces;
using DocumentStore.Requests;
using FluentValidation;

namespace DocumentStore.Validators
{
    public class UpdateDocumentCommandValidator<T> : AbstractValidator<UpdateDocumentCommand<T>> where T : IEntity
    {
        public UpdateDocumentCommandValidator()
        {
            RuleFor(x => x.Document).NotNull();
            RuleFor(x => x.Document).NotNull().NotEmpty();
            RuleFor(x => x.UserId).NotNull().NotEmpty();
        }
    }
}