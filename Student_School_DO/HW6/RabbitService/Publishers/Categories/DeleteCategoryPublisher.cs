using MassTransit;
using Models.Request.Category;
using Models.Response.Category;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Categories
{
    public class DeleteCatergoryPublisher : IDeleteMessagePublisher<int, Task<DeleteCategoryResponse>>
    {
        private readonly IRequestClient<DeleteCategoryResponse> _requestClient;

        public DeleteCatergoryPublisher(IRequestClient<DeleteCategoryResponse> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<DeleteCategoryResponse> SendDeleteMessage(int id)
        {
            DeleteCategoryRequest request = new() { Id = id };

            Response<DeleteCategoryResponse> result =
                await _requestClient.GetResponse<DeleteCategoryResponse>(request);

            return result.Message;
        }
    }
}