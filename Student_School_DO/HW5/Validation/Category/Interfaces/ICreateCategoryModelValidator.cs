using FluentValidation;
using Models;

namespace Validation.Category.Interfaces
{
    public interface ICreateCategoryModelValidator : IValidator<CategoryModel>
    {
    }
}
