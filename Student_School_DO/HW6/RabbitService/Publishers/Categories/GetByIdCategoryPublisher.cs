using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models.Request.Category;
using Models.Response.Category;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Publishers.Categories
{
    public class GetByIdCategoryPublisher : IGetByIdMessagePublisher<int, Task<GetByIdCategoryResponse>>
    {
        private readonly IRequestClient<GetByIdCategoryRequest> _requestClient;

        public GetByIdCategoryPublisher([FromServices] IRequestClient<GetByIdCategoryRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<GetByIdCategoryResponse> SendGetByIdMessage(int id)
        {
            GetByIdCategoryRequest request = new GetByIdCategoryRequest { Id = id };

            Response<GetByIdCategoryResponse> result = await _requestClient.GetResponse<GetByIdCategoryResponse>(request);

            return result.Message;
        }
    }
}
