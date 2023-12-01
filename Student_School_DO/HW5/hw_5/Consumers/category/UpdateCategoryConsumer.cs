using Commands.Commands.Category;
using MassTransit;
using Models;
using Models.Request.Category;
using Models.Response.Category;

namespace RabbitServer.Consumers.Category
{
    public class UpdateCategoryConsumer : IConsumer<UpdateCategoryRequest>
    {
        private readonly ICategoryCommand _command;

        public UpdateCategoryConsumer(ICategoryCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<UpdateCategoryRequest> context)
        {
            Models.Response<int> id = _command.Update(
                context.Message.Category.CategoryId,
                context.Message.Category);

            UpdateCategoryResponse responce = new UpdateCategoryResponse
            {
                Id = id.Value
            };

            await context.RespondAsync(responce);
        }
    }
}
