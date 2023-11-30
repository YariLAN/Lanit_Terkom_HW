using Models.Responce.Book;
using Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class GetAllBookPublisher : IGetAllMessagePublisher<Task<GetAllBookResponse>, BookModel>
    {
        private readonly IRequestClient<BookModel> _requestClient;

        public GetAllBookPublisher([FromServices] IRequestClient<BookModel> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetAllBookResponse> SendGetAllMessage(BookModel request)
        {
            Response<GetAllBookResponse> result =
                await _requestClient.GetResponse<GetAllBookResponse>(request);

            return result.Message;
        }
    }
}
