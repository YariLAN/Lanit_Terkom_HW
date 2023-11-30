using MassTransit;
using Models;
using Models.Request.Reader;
using Models.Responce.Book;
using Models.Response.Reader;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Readers
{
    public class GetAllReaderPublisher : IGetAllMessagePublisher<Task<GetAllReaderResponse>, ReaderModel>
    {
        private readonly IRequestClient<ReaderModel> _requestClient;

        public GetAllReaderPublisher(IRequestClient<ReaderModel> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetAllReaderResponse> SendGetAllMessage(ReaderModel request)
        {
            Response<GetAllReaderResponse> result =
                await _requestClient.GetResponse<GetAllReaderResponse>(request);

            return result.Message;
        }
    }
}
