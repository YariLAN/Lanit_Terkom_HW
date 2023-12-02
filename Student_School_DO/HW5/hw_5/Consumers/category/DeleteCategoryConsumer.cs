using Commands.Commands.Category;
using MassTransit;
using Models;
using Models.Request.Category;
using Models.Responce.Book;
using Models.Response.Category;

namespace RabbitServer.Consumers.Category
{
    public class DeleteCategoryConsumer : IConsumer<DeleteCategoryRequest>
    {
        private readonly ICategoryCommand _command;

        public DeleteCategoryConsumer(ICategoryCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<DeleteCategoryRequest> context)
        {
            Responce<int> result = _command.Delete(context.Message.Id);

            DeleteCategoryResponse responce = new DeleteCategoryResponse
            {
                Id = result.Value,
                Error = result.Messages?.Count > 0 ? result.Messages[0] : ""
            };

            await context.RespondAsync(responce);
        }
    }
}
