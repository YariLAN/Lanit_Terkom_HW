using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Responce.Book;
using Models.Response.Category;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Categories
{
    public class GetAllCategoryPublisher : IGetAllMessagePublisher<Task<GetAllCategoryResponse>, CategoryModel>
    {
        private readonly IRequestClient<CategoryModel> _requestClient;

        public GetAllCategoryPublisher([FromServices] IRequestClient<CategoryModel> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetAllCategoryResponse> SendGetAllMessage(CategoryModel request)
        {
            Response<GetAllCategoryResponse> result =
                await _requestClient.GetResponse<GetAllCategoryResponse>(request);

            return result.Message;
        }
    }
}
