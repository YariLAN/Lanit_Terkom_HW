using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Responce.Book;
using Models.Response.Category;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Categories
{
    public class GetAllCategoryPublisher : IGetAllMessagePublisher<GetAllCategoryResponse, CategoryModel>
    {
        private readonly IRequestClient<CategoryModel> _requestClient;

        public GetAllCategoryPublisher([FromServices] IRequestClient<CategoryModel> requestClient)
        {
            _requestClient = requestClient;
        }

        public GetAllCategoryResponse SendGetAllMessage(CategoryModel request)
        {
            Response<GetAllCategoryResponse> result = _requestClient.GetResponse<GetAllCategoryResponse>(request).Result;

            return result.Message;
        }
    }
}
