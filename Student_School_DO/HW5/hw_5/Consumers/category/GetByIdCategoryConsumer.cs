using Commands.Commands.Category;
using MassTransit;
using Models;
using Models.Request.Category;
using Models.Responce.Book;
using Models.Response.Category;

namespace RabbitServer.Consumers.Category
{
    public class GetByIdCategoryConsumer : IConsumer<GetByIdCategoryRequest>
    {
        private readonly ICategoryCommand _command;

        public GetByIdCategoryConsumer(ICategoryCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<GetByIdCategoryRequest> context)
        {
            Models.Response<CategoryInfo> categories = _command.GetById(context.Message.Id!.Value);

            GetByIdCategoryResponse responce =
                new GetByIdCategoryResponse { Category = categories.Value };

            await context.RespondAsync((object)responce);
        }
    }
}
