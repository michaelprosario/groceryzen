using DocumentStore.Interfaces;
using DocumentStore.Requests;
using FluentValidation;

namespace DocumentStore.Validators
{
    public class StoreDocumentCommandValidator<T> : AbstractValidator<StoreDocumentCommand<T>> where T : IEntity
    {
        public StoreDocumentCommandValidator()
        {
            RuleFor(x => x.Document).NotNull();
            RuleFor(x => x.Document).NotNull().NotEmpty();
            RuleFor(x => x.UserId).NotNull().NotEmpty();
        }
    }
}