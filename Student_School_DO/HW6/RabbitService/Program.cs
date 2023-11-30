using MassTransit;
using Models;
using Models.Request.Book;
using Models.Request.Category;
using Models.Request.Reader;
using Models.Responce.Book;
using Models.Response.Category;
using Models.Response.Reader;
using RabbitClient.Publishers.Books;
using RabbitClient.Publishers.Categories;
using RabbitClient.Publishers.Interfaces;
using RabbitClient.Publishers.Readers;

namespace RabbitClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<ICreateMessagePublisher<CreateBookRequest, Task<CreateBookResponse>>, CreateBookPublisher>();
            builder.Services.AddTransient<IGetByIdMessagePublisher<Guid, Task<GetByIdBookResponse>>, GetByIdBookPublisher>();
            builder.Services.AddTransient<IDeleteMessagePublisher<Guid, Task<DeleteBookResponse>>, DeleteBookPublisher>();
            builder.Services.AddTransient<IGetAllMessagePublisher<Task<GetAllBookResponse>, BookModel>, GetAllBookPublisher>();
            builder.Services.AddTransient<IUpdateMessagePublisher<Guid, BookModel, Task<UpdateBookResponse>>, UpdateBookPublisher>();

            builder.Services.AddTransient<ICreateMessagePublisher<CreateReaderRequest, Task<CreateReaderResponse>>, CreateReaderPublisher>();
            builder.Services.AddTransient<IDeleteMessagePublisher<Guid, Task<DeleteReaderResponse>>, DeleteReaderPublisher>();
            builder.Services.AddTransient<IGetAllMessagePublisher<Task<GetAllReaderResponse>, ReaderModel>, GetAllReaderPublisher>();
            builder.Services.AddTransient<IGetByIdMessagePublisher<Guid, Task<GetByIdReaderResponse>>, GetByIdReaderPublisher>();
            builder.Services.AddTransient<IUpdateMessagePublisher<Guid, ReaderModel, Task<UpdateReaderResponse>>, UpdateReaderPublisher>();

            builder.Services.AddTransient<ICreateMessagePublisher<CreateCategoryRequest, Task<CreateCategoryResponse>>, CreateCategoryPublisher>();
            builder.Services.AddTransient<IDeleteMessagePublisher<int, Task<DeleteCategoryResponse>>, DeleteCatergoryPublisher>();
            builder.Services.AddTransient<IGetAllMessagePublisher<Task<GetAllCategoryResponse>, CategoryModel>, GetAllCategoryPublisher>();
            builder.Services.AddTransient<IGetByIdMessagePublisher<int, Task<GetByIdCategoryResponse>>, GetByIdCategoryPublisher>();
            builder.Services.AddTransient<IUpdateMessagePublisher<int, CategoryModel, Task<UpdateCategoryResponse>>, UpdateCategoryPublisher>();

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