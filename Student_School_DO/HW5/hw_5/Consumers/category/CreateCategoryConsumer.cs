using Commands.Commands.Book;
using Commands.Commands.Category;
using MassTransit;
using Models;
using Models.Request.Book;
using Models.Request.Category;
using Models.Responce.Book;
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
            Responce<int> id = _command.Create(context.Message.Category);

            CreateCategoryResponse responce = new CreateCategoryResponse
            {
                Id = id.Value,
                Error = id.Messages?.Count > 0 ? id.Messages[0] : ""
            };

            await context.RespondAsync(responce);
        }
    }
}