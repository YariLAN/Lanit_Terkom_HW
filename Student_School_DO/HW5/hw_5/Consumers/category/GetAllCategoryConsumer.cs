using Commands.Commands.Category;
using MassTransit;
using Models;
using Models.Responce.Book;
using Models.Response.Category;

namespace RabbitServer.Consumers.Category
{
    public class GetAllCategoryConsumer : IConsumer<CategoryModel>
    {
        private readonly ICategoryCommand _command;

        public GetAllCategoryConsumer(ICategoryCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<CategoryModel> context)
        {
            IEnumerable<CategoryModel> result = _command.GetAll().Value;

            var allBook = new GetAllCategoryResponse { Categories = result };

            await context.RespondAsync(allBook);
        }
    }
}
