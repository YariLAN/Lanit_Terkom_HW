using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class GetByIdBookPublisher : IGetByIdMessagePublisher<Guid, Task<GetByIdBookResponce>>
    {
        private readonly IRequestClient<GetByIdBookRequest> _requestClient;

        public GetByIdBookPublisher(IRequestClient<GetByIdBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetByIdBookResponce> SendGetByIdMessage(Guid id)
        {
            GetByIdBookRequest request = new GetByIdBookRequest { Id = id };

            Response<GetByIdBookResponce> result = await _requestClient.GetResponse<GetByIdBookResponce>(request);

            return result.Message;
        }
    }
}
