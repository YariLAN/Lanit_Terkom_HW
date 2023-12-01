using FluentValidation;
using Models;

namespace Validation.Genre.Interfaces
{
    public interface ICreateGenreModelValidator : IValidator<GenreInfo>
    {
    }
}
