using Models.Responce.Book;
using Models;
using Models.Request.Book;
using MassTransit;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class UpdateBookPublisher : IUpdateMessagePublisher<Guid, BookModel, UpdateBookResponce>
    {
        private readonly IRequestClient<UpdateBookRequest> _requestClient;

        public UpdateBookPublisher(IRequestClient<UpdateBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public UpdateBookResponce SendUpdateMessage(Guid id, BookModel request)
        {
            request.BookId = id;

            UpdateBookRequest req = new UpdateBookRequest { Book = request };

            Response<UpdateBookResponce> result =
                _requestClient.GetResponse<UpdateBookResponce>(req).Result;

            return result.Message;
        }
    }
}
