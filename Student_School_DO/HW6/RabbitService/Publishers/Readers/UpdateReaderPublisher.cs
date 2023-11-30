using MassTransit;
using Models;
using Models.Request.Reader;
using Models.Response.Reader;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Readers
{
    public class UpdateReaderPublisher : IUpdateMessagePublisher<Guid, ReaderModel, Task<UpdateReaderResponse>>
    {
        private readonly IRequestClient<UpdateReaderRequest> _requestClient;

        public UpdateReaderPublisher(IRequestClient<UpdateReaderRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<UpdateReaderResponse> SendUpdateMessage(Guid id, ReaderModel request)
        {
            request.ReaderId = id;

            UpdateReaderRequest req = new() { Reader = request };

            Response<UpdateReaderResponse> result =
                await _requestClient.GetResponse<UpdateReaderResponse>(req);

            return result.Message;
        }
    }
}
