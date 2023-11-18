using Commands.Interfaces;
using Models;

namespace Commands.Commands.Book
{
    public interface IBookCommand :
        ICreateCommand<BookModel, Guid>,
        IUpdateCommand<BookModel, Guid>,
        IGetAllCommand<BookModel>,
        IGetByIdCommand<Guid, BookModel>,
        IDeleteCommand<Guid>
    {

    }
}
