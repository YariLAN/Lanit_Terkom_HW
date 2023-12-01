using FluentValidation;
using Models;
using Validation.Reader.Interfaces;

namespace Validation.Reader
{
    public class CreateReaderModelValidator :
        AbstractValidator<ReaderInfo>,
        ICreateReaderModelValidator
    {
        public CreateReaderModelValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage(x => x.LastName)
                .MaximumLength(50)
                .WithMessage("Last name is very long");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is empty")
                .MaximumLength(50)
                .WithMessage("First name is very long");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is empty")
                .MaximumLength(50)
                .WithMessage("Max length");

            RuleFor(x => x.Patronymic)
                .NotEmpty()
                .WithMessage("Patronymic is empty")
                .MaximumLength(80)
                .WithMessage("Patronymic is very long");
        }
    }
}
