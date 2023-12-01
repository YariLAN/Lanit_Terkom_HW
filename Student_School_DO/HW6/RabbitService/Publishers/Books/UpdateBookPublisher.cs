using Models.Responce.Book;
using Models;
using Models.Request.Book;
using MassTransit;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class UpdateBookPublisher : IUpdateMessagePublisher<Guid, BookInfo, Task<UpdateBookResponse>>
    {
        private readonly IRequestClient<UpdateBookRequest> _requestClient;

        public UpdateBookPublisher(IRequestClient<UpdateBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<UpdateBookResponse> SendUpdateMessage(Guid id, BookInfo request)
        {
            request.BookId = id;

            UpdateBookRequest req = new UpdateBookRequest { Book = request };

            MassTransit.Response<UpdateBookResponse> result =
                await _requestClient.GetResponse<UpdateBookResponse>(req);

            return result.Message;
        }
    }
}
