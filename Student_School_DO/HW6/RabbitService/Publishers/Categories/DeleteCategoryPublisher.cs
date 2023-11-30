using MassTransit;
using Models.Request.Category;
using Models.Response.Category;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Categories
{
    public class DeleteCatergoryPublisher : IDeleteMessagePublisher<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private readonly IRequestClient<DeleteCategoryResponse> _requestClient;

        public DeleteCatergoryPublisher(IRequestClient<DeleteCategoryResponse> requestClient)
        {
            _requestClient = requestClient;
        }

        public DeleteCategoryResponse SendDeleteMessage(DeleteCategoryRequest id)
        {
            Response<DeleteCategoryResponse> result = _requestClient.GetResponse<DeleteCategoryResponse>(request).Result;

            return result.Message;
        }
    }
}