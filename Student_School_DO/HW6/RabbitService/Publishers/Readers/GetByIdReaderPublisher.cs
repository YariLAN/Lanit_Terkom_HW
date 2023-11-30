using MassTransit;
using Models.Response.Reader;
using Models;
using RabbitClient.Publishers.Interfaces;
using Models.Request.Reader;

namespace RabbitClient.Publishers.Readers
{
    public class GetByIdReaderPublisher : IGetByIdMessagePublisher<Guid, Task<GetByIdReaderResponse>>
    {
        private readonly IRequestClient<GetByIdReaderRequest> _requestClient;

        public GetByIdReaderPublisher(IRequestClient<GetByIdReaderRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetByIdReaderResponse> SendGetByIdMessage(Guid id)
        {
            GetByIdReaderRequest request = new() { Id = id };

            Response<GetByIdReaderResponse> result =
                await _requestClient.GetResponse<GetByIdReaderResponse>(request);

            return result.Message;
        }
    }
}
