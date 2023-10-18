using DocumentStore.Requests;
using FluentValidation;

namespace DocumentStore.Validators
{
    public class AddFileCommandValidator : AbstractValidator<AddFileCommand>
    {
        public AddFileCommandValidator()
        {
            RuleFor(x => x.FileId).NotNull().NotEmpty();
            RuleFor(x => x.FileName).NotNull().NotEmpty();
        }
    }
}