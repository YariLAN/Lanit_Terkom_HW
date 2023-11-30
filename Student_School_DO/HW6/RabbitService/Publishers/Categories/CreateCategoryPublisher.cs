using MassTransit;
using Models.Request.Category;
using Models.Response.Category;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Categories
{
    public class CreateCategoryPublisher : ICreateMessagePublisher<CreateCategoryRequest, CreateCategoryResponse>
    {
        private readonly IRequestClient<CreateCategoryRequest> _requestClient;

        public CreateCategoryPublisher(IRequestClient<CreateCategoryRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public CreateCategoryResponse SendCreateMessage(CreateCategoryRequest request)
        {
            Response<CreateCategoryResponse> result = _requestClient.GetResponse<CreateCategoryResponse>(request).Result;

            return result.Message;
        }
    }
}