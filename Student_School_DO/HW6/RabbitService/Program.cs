using MassTransit;
using Models;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Books;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<ICreateMessagePublisher<CreateBookRequest, CreateBookResponse>,CreateBookPublisher>();
            builder.Services.AddTransient<IGetByIdMessagePublisher<Guid, Task<GetByIdBookResponse>>, GetByIdBookPublisher>();
            builder.Services.AddTransient<IDeleteMessagePublisher<DeleteBookRequest, DeleteBookResponse>, DeleteBookPublisher>();
            builder.Services.AddTransient<IGetAllMessagePublisher<GetAllBookResponse, BookModel>, GetAllBookPublisher>();
            builder.Services.AddTransient<IUpdateMessagePublisher<Guid, BookModel, UpdateBookResponse>, UpdateBookPublisher>();

            try
            {
                builder.Services.AddMassTransit(x =>
                {
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("localhost");
                        cfg.ConfigureEndpoints(context);
                    });
                });
            }
            catch (Exception)
            {
                throw new Exception("Failed to connect to RabbitMQ");
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}