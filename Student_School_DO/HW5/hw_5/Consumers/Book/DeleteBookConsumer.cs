using Commands.Commands.Book;
using MassTransit;
using Models.Responce.Book;
using Models;

using Models.Request.Book;

namespace RabbitServer.Consumers.Book
{
    public class DeleteBookConsumer : IConsumer<DeleteBookRequest>
    {
        private readonly IBookCommand _command;

        public DeleteBookConsumer(IBookCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<DeleteBookRequest> context)
        {
            Responce<Guid> result = _command.Delete(context.Message.Id);

            DeleteBookResponse responce = new DeleteBookResponse
            {
                Id = result.Value,
                Error = result.Messages?.Count > 0 ? result.Messages[0] : ""
            };

            await context.RespondAsync(responce);
        }
    }
}
