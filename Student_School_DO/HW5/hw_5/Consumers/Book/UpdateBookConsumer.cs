using Commands.Commands.Book;
using MassTransit;
using Models;
using Models.Request.Book;
using Models.Responce.Book;

namespace RabbitServer.Consumers.Book
{
    public class UpdateBookConsumer : IConsumer<UpdateBookRequest>
    {
        private readonly IBookCommand _command;

        public UpdateBookConsumer(IBookCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<UpdateBookRequest> context)
        {
            Responce<Guid> id = _command.Update(context.Message.Book.BookId, context.Message.Book);

            UpdateBookResponse responce = new UpdateBookResponse
            {
                Id = id.Value
            };

            await context.RespondAsync(responce);
        }
    }
}
