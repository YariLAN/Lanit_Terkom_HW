using MassTransit;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class DeleteBookPublisher : IDeleteMessagePublisher<Guid, Task<DeleteBookResponse>>
    {
        private readonly IRequestClient<DeleteBookRequest> _requestClient;

        public DeleteBookPublisher(IRequestClient<DeleteBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<DeleteBookResponse> SendDeleteMessage(Guid id)
        {
            DeleteBookRequest request = new() { Id = id };

            Response<DeleteBookResponse> result =
                await _requestClient.GetResponse<DeleteBookResponse>(request);

            return result.Message;
        }
    }
}
