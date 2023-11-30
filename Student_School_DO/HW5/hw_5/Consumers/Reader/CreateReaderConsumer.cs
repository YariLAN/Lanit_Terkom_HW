using Commands.Commands.Reader;
using MassTransit;
using Models.Response.Reader;
using Models;
using Models.Request.Reader;
using Models.Responce.Book;

namespace RabbitServer.Consumers.Reader
{
    public class CreateReaderConsumer : IConsumer<CreateReaderRequest>
    {
        private readonly IReaderCommand _command;

        public CreateReaderConsumer(IReaderCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<CreateReaderRequest> context)
        {
            Responce<Guid> result = _command.Create(context.Message.Reader);

            CreateReaderResponse responce = new()
            {
                Id = result.Value,
                Error = result.Errors?.Count > 0 ? result.Errors[0] : ""
            };

            await context.RespondAsync(responce);
        }
    }
}
