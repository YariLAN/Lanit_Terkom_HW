using MassTransit;
using Models;
using Models.Request.Book;
using Models.Responce.Book;

namespace RabbitClient.Publishers.Books
{
    public class BookPublisher : IBookPublisher
    {
        private readonly IRequestClient<BookModel> _requestClient;

        public BookPublisher
            (IRequestClient<BookModel> requestClient)
        {
            _requestClient = requestClient;
        }

        public CreateBookResponce SendCreateMessage(BookModel request)
        {
            Response<CreateBookResponce> result = _requestClient.GetResponse<CreateBookResponce>(request).Result;

            return result.Message;
        }

        public DeleteBookResponce SendDeleteMessage(DeleteBookRequest request)
        {
            Response<DeleteBookResponce> result = _requestClient.GetResponse<DeleteBookResponce>(request).Result;

            return result.Message;
        }

        public GetAllBookResponce SendGetAllMessage(BookModel request)
        {
            Response<GetAllBookResponce> result = _requestClient.GetResponse<GetAllBookResponce>(request).Result;

            return result.Message;
        }

        public BookModel SendGetByIdMessage(Guid id)
        {
            GetByIdBookRequest request = new GetByIdBookRequest { Id = id };

            Response<BookModel> result =
                _requestClient.GetResponse<BookModel>(request).Result;

            return result.Message;
        }

        public UpdateBookResponce SendUpdateMessage(Guid id, BookModel request)
        {
            request.BookId = id;

            Response<UpdateBookResponce> result =
                _requestClient.GetResponse<UpdateBookResponce>(request).Result;

            return result.Message;
        }
    }
}
