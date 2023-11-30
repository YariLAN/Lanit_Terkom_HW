using Commands.Commands.Book;
using MassTransit;
using Models;
using Models.Responce.Book;

namespace RabbitServer.Consumers.Book
{
    public class GetAllBookConsumer : IConsumer<BookModel>
    {
        private readonly IBookCommand _command;

        public GetAllBookConsumer(IBookCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<BookModel> context)
        {
            IEnumerable<BookModel> result = _command.GetAll().Value;

            var allBook = new GetAllBookResponse { Books = result };

            await context.RespondAsync(allBook);
        }
    }
}
