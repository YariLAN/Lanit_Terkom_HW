using MassTransit;
using Models;
using Models.Request.Reader;
using Models.Responce.Book;
using Models.Response.Reader;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Readers
{
    public class GetAllReaderPublisher : IGetAllMessagePublisher<Task<GetAllReaderResponse>, ReaderInfo>
    {
        private readonly IRequestClient<ReaderInfo> _requestClient;

        public GetAllReaderPublisher(IRequestClient<ReaderInfo> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetAllReaderResponse> SendGetAllMessage(ReaderInfo request)
        {
            MassTransit.Response<GetAllReaderResponse> result =
                await _requestClient.GetResponse<GetAllReaderResponse>(request);

            return result.Message;
        }
    }
}
