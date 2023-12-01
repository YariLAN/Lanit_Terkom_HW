using Commands.Commands.Reader;
using MassTransit;
using Models.Response.Reader;
using Models;
using Models.Request.Reader;

namespace RabbitServer.Consumers.Reader
{
    public class GetByIdReaderConsumer : IConsumer<GetByIdReaderRequest>
    {
        private readonly IReaderCommand _command;

        public GetByIdReaderConsumer(IReaderCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<GetByIdReaderRequest> context)
        {
            Models.Response<ReaderInfo> result = _command.GetById(context.Message.Id);

            GetByIdReaderResponse allBook = new() { Reader = result.Value };

            await context.RespondAsync(allBook);
        }
    }
}
