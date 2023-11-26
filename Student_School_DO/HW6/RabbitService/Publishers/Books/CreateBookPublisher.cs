using MassTransit;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class CreateBookPublisher : ICreateMessagePublisher<CreateBookRequest, CreateBookResponce>
    {
        private readonly IRequestClient<CreateBookRequest> _requestClient;

        public CreateBookPublisher(IRequestClient<CreateBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public CreateBookResponce SendCreateMessage(CreateBookRequest request)
        {
            Response<CreateBookResponce> result = _requestClient.GetResponse<CreateBookResponce>(request).Result;

            return result.Message;
        }
    }
}
