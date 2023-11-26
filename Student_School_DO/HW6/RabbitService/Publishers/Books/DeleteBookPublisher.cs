using MassTransit;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class DeleteBookPublisher : IDeleteMessagePublisher<DeleteBookRequest, DeleteBookResponce>
    {
        private readonly IRequestClient<DeleteBookRequest> _requestClient;

        public DeleteBookPublisher(IRequestClient<DeleteBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public DeleteBookResponce SendDeleteMessage(DeleteBookRequest id)
        {
            Response<DeleteBookResponce> result = _requestClient.GetResponse<DeleteBookResponce>(id).Result;

            return result.Message;
        }
    }
}
