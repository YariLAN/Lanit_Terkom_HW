using Commands.Commands.Category;
using MassTransit;
using Models;
using Models.Responce.Book;
using Models.Response.Category;

namespace RabbitServer.Consumers.Category
{
    public class GetAllCategoryConsumer : IConsumer<CategoryInfo>
    {
        private readonly ICategoryCommand _command;

        public GetAllCategoryConsumer(ICategoryCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<CategoryInfo> context)
        {
            IEnumerable<CategoryInfo> result = _command.GetAll().Value;

            var allBook = new GetAllCategoryResponse { Categories = result };

            await context.RespondAsync(allBook);
        }
    }
}
