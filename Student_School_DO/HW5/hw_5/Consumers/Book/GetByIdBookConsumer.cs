using Commands.Commands.Book;
using MassTransit;
using Models;
using Models.Request.Book;

namespace RabbitServer.Consumers.Book
{
    public class GetByIdBookConsumer : IConsumer<GetByIdBookRequest>
    {
        private readonly IBookCommand _command;

        public GetByIdBookConsumer(IBookCommand command)
        {
            _command = command;
        }

        public Task Consume(ConsumeContext<GetByIdBookRequest> context)
        {
            BookModel responce = _command.GetById(context.Message.Id).Value;

            context.Respond(responce);

            return Task.CompletedTask;
        }
    }
}
