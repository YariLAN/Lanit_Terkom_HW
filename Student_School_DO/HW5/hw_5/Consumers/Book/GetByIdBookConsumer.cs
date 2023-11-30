using Commands.Commands.Book;
using MassTransit;
using Models;
using Models.Request.Book;
using Models.Responce.Book;

namespace RabbitServer.Consumers.Book
{
    public class GetByIdBookConsumer : IConsumer<GetByIdBookRequest>
    {
        private readonly IBookCommand _command;

        public GetByIdBookConsumer(IBookCommand command)
        {
            _command = command;
        }

        public async Task Consume(ConsumeContext<GetByIdBookRequest> context)
        {
            Responce<BookModel> book = _command.GetById(context.Message.Id);

            GetByIdBookResponse responce = new GetByIdBookResponse { Book = book.Value };

            await context.RespondAsync((object)responce);
        }
    }
}
