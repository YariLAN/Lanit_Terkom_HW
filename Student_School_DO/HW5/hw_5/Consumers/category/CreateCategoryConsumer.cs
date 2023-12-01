using Commands.Commands.Category;
using MassTransit;
using Models.Request.Category;
using Models.Response.Category;

namespace RabbitServer.Consumers.Category
{
    public class CreateCategoryConsumer : IConsumer<CreateCategoryRequest>
    {
        private readonly ICategoryCommand _command;

        public CreateCategoryConsumer(ICategoryCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<CreateCategoryRequest> context)
        {
            Models.Response<int> id = _command.Create(context.Message.Category);

            CreateCategoryResponse responce = new CreateCategoryResponse
            {
                Id = id.Value,
                Error = id.Errors?.Count > 0 ? id.Errors[0] : ""
            };

            await context.RespondAsync(responce);
        }
    }
}