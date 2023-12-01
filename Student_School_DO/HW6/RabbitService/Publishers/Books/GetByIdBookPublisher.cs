using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Books
{
    public class GetByIdBookPublisher : IGetByIdMessagePublisher<Guid, Task<GetByIdBookResponse>>
    {
        private readonly IRequestClient<GetByIdBookRequest> _requestClient;

        public GetByIdBookPublisher(IRequestClient<GetByIdBookRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetByIdBookResponse> SendGetByIdMessage(Guid id)
        {
            GetByIdBookRequest request = new GetByIdBookRequest { Id = id };

            MassTransit.Response<GetByIdBookResponse> result = await _requestClient.GetResponse<GetByIdBookResponse>(request);

            return result.Message;
        }
    }
}
