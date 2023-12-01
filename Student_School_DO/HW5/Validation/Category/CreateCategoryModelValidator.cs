using FluentValidation;
using Models;
using Validation.Category.Interfaces;

namespace Validation.Category
{
    public class CreateCategoryModelValidator :
        AbstractValidator<CategoryInfo>,
        ICreateCategoryModelValidator
    {
        public CreateCategoryModelValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty()
             .WithMessage("Name is empty")
             .MaximumLength(50)
             .WithMessage("Name is very long");
        }
    }
}
