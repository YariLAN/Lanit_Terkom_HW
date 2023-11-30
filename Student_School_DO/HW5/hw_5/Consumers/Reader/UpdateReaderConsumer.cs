using Commands.Commands.Reader;
using MassTransit;
using Models;
using Models.Request.Reader;
using Models.Response.Reader;

namespace RabbitServer.Consumers.Reader
{
    public class UpdateReaderConsumer : IConsumer<UpdateReaderRequest>
    {
        private readonly IReaderCommand _command;

        public UpdateReaderConsumer(IReaderCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<UpdateReaderRequest> context)
        {
            Responce<Guid> result = _command.Update(
                context.Message.Reader.ReaderId,
                context.Message.Reader);

            UpdateReaderResponse responce = new()
            {
                Id = result.Value
            };

            await context.RespondAsync(responce);
        }
    }
}
