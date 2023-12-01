using Commands.Commands.Reader;
using MassTransit;
using Models;
using Models.Request.Reader;
using Models.Response.Reader;

namespace RabbitServer.Consumers.Reader
{
    public class DeleteReaderConsumer : IConsumer<DeleteReaderRequest>
    {
        private readonly IReaderCommand _command;

        public DeleteReaderConsumer(IReaderCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<DeleteReaderRequest> context)
        {
            Models.Response<Guid> result = _command.Delete(context.Message.Id);

            DeleteReaderResponse responce = new DeleteReaderResponse
            {
                Id = result.Value,
                Error = result.Errors?.Count > 0 ? result.Errors[0] : ""
            };

            await context.RespondAsync(responce);
        }
    }
}
