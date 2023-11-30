using MassTransit;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class CreateBookPublisher : ICreateMessagePublisher<CreateBookRequest, CreateBookResponse>
    {
        private readonly IRequestClient<CreateBookRequest> _requestClient;

        public CreateBookPublisher(IRequestClient<CreateBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public CreateBookResponse SendCreateMessage(CreateBookRequest request)
        {
            Response<CreateBookResponse> result = _requestClient.GetResponse<CreateBookResponse>(request).Result;

            return result.Message;
        }
    }
}
