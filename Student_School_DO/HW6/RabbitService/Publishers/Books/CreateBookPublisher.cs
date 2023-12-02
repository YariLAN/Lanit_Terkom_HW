using MassTransit;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class CreateBookPublisher : ICreateMessagePublisher<CreateBookRequest, Task<CreateBookResponse>>
    {
        private readonly IRequestClient<CreateBookRequest> _requestClient;

        public CreateBookPublisher(IRequestClient<CreateBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<CreateBookResponse> SendCreateMessage(CreateBookRequest request)
        {
            Response<CreateBookResponse> result =
                await _requestClient.GetResponse<CreateBookResponse>(request);

            return result.Message;
        }
    }
}
