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

            builder.Services.AddTransient<ICreateMessagePublisher<CreateBookRequest, CreateBookResponce>,CreateBookPublisher>();
            builder.Services.AddTransient<IGetByIdMessagePublisher<Guid, Task<GetByIdBookResponce>>, GetByIdBookPublisher>();
            builder.Services.AddTransient<IDeleteMessagePublisher<DeleteBookRequest, DeleteBookResponce>, DeleteBookPublisher>();
            builder.Services.AddTransient<IGetAllMessagePublisher<GetAllBookResponce, BookModel>, GetAllBookPublisher>();
            builder.Services.AddTransient<IUpdateMessagePublisher<Guid, BookModel, UpdateBookResponce>, UpdateBookPublisher>();

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