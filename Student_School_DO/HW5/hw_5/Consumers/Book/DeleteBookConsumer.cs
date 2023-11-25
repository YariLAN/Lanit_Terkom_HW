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

        public Task Consume(ConsumeContext<DeleteBookRequest> context)
        {
            Responce<Guid> result = _command.Delete(context.Message.Id);

            DeleteBookResponce responce = new DeleteBookResponce
            {
                Id = result.Value,
                Error = result.Errors[0]
            };

            context.Respond(responce);

            return Task.CompletedTask;
        }
    }
}
