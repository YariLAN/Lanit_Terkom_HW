using MassTransit;
using Models.Request.Book;
using Models.Request.Reader;
using Models.Responce.Book;
using Models.Response.Reader;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Readers
{
    public class CreateReaderPublisher : ICreateMessagePublisher<CreateReaderRequest, Task<CreateReaderResponse>>
    {
        private readonly IRequestClient<CreateReaderRequest> _requestClient;

        public CreateReaderPublisher(IRequestClient<CreateReaderRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<CreateReaderResponse> SendCreateMessage(CreateReaderRequest request)
        {
            Response<CreateReaderResponse> result =
                await _requestClient.GetResponse<CreateReaderResponse>(request);

            return result.Message;
        }
    }
}
