using Models;
using Models.Request.Book;
using Models.Responce.Book;

namespace RabbitClient.Publishers.Books
{
    public interface IBookPublisher :
        ICreateMessagePublisher<BookModel, CreateBookResponce>,
        IUpdateMessagePublisher<Guid, BookModel, UpdateBookResponce>,
        IDeleteMessagePublisher<DeleteBookRequest, DeleteBookResponce>,
        IGetAllMessagePublisher<GetAllBookResponce, BookModel>,
        IGetByIdMessagePublisher<Guid, BookModel>
    {
    }
}
