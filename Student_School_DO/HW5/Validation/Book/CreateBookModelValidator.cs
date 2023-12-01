using FluentValidation;
using Models;
using Validation.Book.Interfaces;

namespace Validation.Book
{
    public class CreateBookModelValidator :
        AbstractValidator<BookInfo>,
        ICreateBookModelValidator
    {
        public CreateBookModelValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(request => request.Name)
              .NotEmpty()
              .WithMessage("Field `Name` don't must be empty");

            RuleFor(request => request.Author)
                .NotEmpty()
                .WithMessage("Field `Author` don't must be empty");

            RuleFor(request => request.CountBook)
                .NotEmpty()
                .WithMessage("Count is empty")
                .Must(x => x >= 0)
                .WithMessage("Count can't be < 0");
        }
    }
}
