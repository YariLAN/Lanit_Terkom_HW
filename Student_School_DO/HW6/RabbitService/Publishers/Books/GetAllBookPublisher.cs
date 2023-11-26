using Models.Responce.Book;
using Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class GetAllBookPublisher : IGetAllMessagePublisher<GetAllBookResponce, BookModel>
    {
        private readonly IRequestClient<BookModel> _requestClient;

        public GetAllBookPublisher([FromServices] IRequestClient<BookModel> requestClient)
        {
            _requestClient = requestClient;
        }

        public GetAllBookResponce SendGetAllMessage(BookModel request)
        {
            Response<GetAllBookResponce> result = _requestClient.GetResponse<GetAllBookResponce>(request).Result;

            return result.Message;
        }
    }
}
