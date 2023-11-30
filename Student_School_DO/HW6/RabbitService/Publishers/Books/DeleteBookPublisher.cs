using MassTransit;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class DeleteBookPublisher : IDeleteMessagePublisher<DeleteBookRequest, DeleteBookResponse>
    {
        private readonly IRequestClient<DeleteBookRequest> _requestClient;

        public DeleteBookPublisher(IRequestClient<DeleteBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public DeleteBookResponse SendDeleteMessage(DeleteBookRequest id)
        {
            Response<DeleteBookResponse> result = _requestClient.GetResponse<DeleteBookResponse>(id).Result;

            return result.Message;
        }
    }
}
