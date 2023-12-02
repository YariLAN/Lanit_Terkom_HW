using MassTransit;
using Models.Request.Category;
using Models.Response.Category;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Categories
{
    public class CreateCategoryPublisher : ICreateMessagePublisher<CreateCategoryRequest, Task<CreateCategoryResponse>>
    {
        private readonly IRequestClient<CreateCategoryRequest> _requestClient;

        public CreateCategoryPublisher(IRequestClient<CreateCategoryRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<CreateCategoryResponse> SendCreateMessage(CreateCategoryRequest request)
        {
            Response<CreateCategoryResponse> result =
                await  _requestClient.GetResponse<CreateCategoryResponse>(request);

            return result.Message;
        }
    }
}