using Commands.Commands.Book;
using MassTransit;
using Models;
using Models.Responce.Book;

namespace RabbitServer.Consumers.Book
{
    public class GetAllBookConsumer : IConsumer<BookInfo>
    {
        private readonly IBookCommand _command;

        public GetAllBookConsumer(IBookCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<BookInfo> context)
        {
            IEnumerable<BookInfo> result = _command.GetAll().Value;

            var allBook = new GetAllBookResponse { Books = result };

            await context.RespondAsync(allBook);
        }
    }
}
