using FluentValidation;
using Models;

namespace Validation.Book.Interfaces
{
    public interface ICreateBookModelValidator : IValidator<BookInfo>
    {
    }
}
