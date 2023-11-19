using FluentValidation;
using Models;
using Validation.Genre.Interfaces;

namespace Validation.Genre
{
    public class CreateGenreModelValidator :
        AbstractValidator<GenreModel>,
        ICreateGenreModelValidator
    {
        public CreateGenreModelValidator()
        {
            RuleFor(request => request.Name)
              .NotEmpty()
              .WithMessage("Field `Name` don't must be empty")
              .MaximumLength(50)
              .WithMessage("Name is a really long!");
        }
    }
}
