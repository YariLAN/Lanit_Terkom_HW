using Commands.Commands.Book;
using MassTransit;
using Models;
using Models.Responce.Book;

namespace RabbitServer.Consumers.Book
{
    public class CreateBookConsumer : IConsumer<BookModel>
    {
        private readonly IBookCommand _command;

        public CreateBookConsumer(IBookCommand command)
        {
            _command = command;
        }

        public Task Consume(ConsumeContext<BookModel> context)
        {
            Responce<Guid> id = _command.Create(context.Message);

            CreateBookResponce responce = new CreateBookResponce
            {
                Id = id.Value,
                Error = id.Errors?.Count > 0 ? id.Errors[0] : ""
            };

            context.Respond(responce);

            return Task.CompletedTask;
        }
    }
}
