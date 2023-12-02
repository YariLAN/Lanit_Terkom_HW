using MassTransit;
using Models.Request.Reader;
using Models.Responce.Book;
using Models.Response.Reader;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Readers
{
    public class DeleteReaderPublisher : IDeleteMessagePublisher<Guid, Task<DeleteReaderResponse>>
    {
        private readonly IRequestClient<DeleteReaderRequest> _requestClient;

        public DeleteReaderPublisher(IRequestClient<DeleteReaderRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<DeleteReaderResponse> SendDeleteMessage(Guid id)
        {
            DeleteReaderRequest request = new() { Id = id };

            Response<DeleteReaderResponse> result =
                await _requestClient.GetResponse<DeleteReaderResponse>(request);

            return result.Message;
        }
    }
}
