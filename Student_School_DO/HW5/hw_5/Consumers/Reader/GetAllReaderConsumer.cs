using Commands.Commands.Book;
using Commands.Commands.Reader;
using MassTransit;
using Models;
using Models.Responce.Book;
using Models.Response.Reader;

namespace RabbitServer.Consumers.Reader
{
    public class GetAllReaderConsumer : IConsumer<ReaderModel>
    {
        private readonly IReaderCommand _command;

        public GetAllReaderConsumer(IReaderCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<ReaderModel> context)
        {
            IEnumerable<ReaderModel> result = _command.GetAll().Value;

            var allBook = new GetAllReaderResponse { Readers = result };

            await context.RespondAsync(allBook);
        }
    }
}
