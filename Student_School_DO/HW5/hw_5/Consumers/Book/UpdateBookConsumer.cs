using Commands.Commands.Book;
using MassTransit;
using Models;
using Models.Responce.Book;

namespace RabbitServer.Consumers.Book
{
    public class UpdateBookConsumer : IConsumer<BookModel>
    {
        private readonly IBookCommand _command;

        public UpdateBookConsumer(IBookCommand command)
        {
            _command = command;
        }

        public Task Consume(ConsumeContext<BookModel> context)
        {
            Responce<Guid> id = _command.Update(context.Message.BookId, context.Message);

            UpdateBookResponce responce = new UpdateBookResponce
            {
                Id = id.Value
            };

            context.Respond(responce);

            return Task.CompletedTask;
        }
    }
}
