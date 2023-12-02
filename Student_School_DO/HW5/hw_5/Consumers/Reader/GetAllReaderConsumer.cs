using Commands.Commands.Book;
using Commands.Commands.Reader;
using MassTransit;
using Models;
using Models.Responce.Book;
using Models.Response.Reader;

namespace RabbitServer.Consumers.Reader
{
    public class GetAllReaderConsumer : IConsumer<ReaderInfo>
    {
        private readonly IReaderCommand _command;

        public GetAllReaderConsumer(IReaderCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<ReaderInfo> context)
        {
            IEnumerable<ReaderInfo> result = _command.GetAll().Value;

            var allBook = new GetAllReaderResponse { Readers = result };

            await context.RespondAsync(allBook);
        }
    }
}
