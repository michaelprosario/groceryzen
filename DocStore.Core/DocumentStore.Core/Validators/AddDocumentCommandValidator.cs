using DocumentStore.Interfaces;
using DocumentStore.Requests;
using FluentValidation;

namespace DocumentStore.Validators
{
    public class AddDocumentCommandValidator<T> : AbstractValidator<AddDocumentCommand<T>> where T : IEntity
    {
        public AddDocumentCommandValidator()
        {
            RuleFor(x => x.Document).NotNull();
            RuleFor(x => x.UserId).NotNull().NotEmpty();
        }
    }
}