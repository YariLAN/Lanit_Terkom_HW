using Commands.Commands.Book;
using MassTransit;
using Models;
using Models.Request.Book;
using Models.Responce.Book;

namespace RabbitServer.Consumers.Book
{
    public class CreateBookConsumer : IConsumer<CreateBookRequest>
    {
        private readonly IBookCommand _command;

        public CreateBookConsumer(IBookCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<CreateBookRequest> context)
        {
            Models.Response<Guid> id = _command.Create(context.Message.Book);

            CreateBookResponse responce = new CreateBookResponse
            {
                Id = id.Value,
                Error = id.Messages?.Count > 0 ? id.Messages[0] : ""
            };

            await context.RespondAsync(responce);
        }
    }
}
