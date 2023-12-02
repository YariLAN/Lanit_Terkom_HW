using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Responce.Book;
using Models.Response.Category;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Categories
{
    public class GetAllCategoryPublisher : IGetAllMessagePublisher<Task<GetAllCategoryResponse>, CategoryInfo>
    {
        private readonly IRequestClient<CategoryInfo> _requestClient;

        public GetAllCategoryPublisher([FromServices] IRequestClient<CategoryInfo> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetAllCategoryResponse> SendGetAllMessage(CategoryInfo request)
        {
            MassTransit.Response<GetAllCategoryResponse> result =
                await _requestClient.GetResponse<GetAllCategoryResponse>(request);

            return result.Message;
        }
    }
}
