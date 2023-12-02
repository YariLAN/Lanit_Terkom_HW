using Models.Responce.Book;
using Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class GetAllBookPublisher : IGetAllMessagePublisher<Task<GetAllBookResponse>, BookInfo>
    {
        private readonly IRequestClient<BookInfo> _requestClient;

        public GetAllBookPublisher([FromServices] IRequestClient<BookInfo> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetAllBookResponse> SendGetAllMessage(BookInfo request)
        {
            MassTransit.Response<GetAllBookResponse> result =
                await _requestClient.GetResponse<GetAllBookResponse>(request);

            return result.Message;
        }
    }
}
