using Commands.Interfaces;
using Models;

namespace Commands.Commands.Book
{
    public interface IBookCommand :
        ICreateCommand<BookInfo, Guid>,
        IUpdateCommand<BookInfo, Guid>,
        IGetAllCommand<BookInfo>,
        IGetByIdCommand<Guid, BookInfo>,
        IDeleteCommand<Guid>
    {

    }
}
