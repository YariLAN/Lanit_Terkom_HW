using MassTransit;
using Models;
using Models.Request.Book;
using Models.Request.Category;
using Models.Responce.Book;
using Models.Response.Category;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Categories
{
    public class UpdateCategoryPublisher : IUpdateMessagePublisher<int, CategoryModel, Task<UpdateCategoryResponse>>
    {
        private readonly IRequestClient<UpdateCategoryRequest> _requestClient;

        public UpdateCategoryPublisher(IRequestClient<UpdateCategoryRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<UpdateCategoryResponse> SendUpdateMessage(int id, CategoryModel request)
        {
            request.CategoryId = id;

            UpdateCategoryRequest req = new UpdateCategoryRequest { Category = request };

            Response<UpdateCategoryResponse> result =
                await _requestClient.GetResponse<UpdateCategoryResponse>(req);

            return result.Message;
        }
    }
}
