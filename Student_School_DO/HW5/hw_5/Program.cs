using Commands.Commands.Book;
using Commands.Commands.Category;
using Commands.Commands.Genre;
using Commands.Commands.Issued;
using Commands.Commands.Reader;
using EntitiesEF;
using Models;
using Repositories;
using System.Text.Json.Serialization;

namespace hw_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // IgnoreCycles
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // DI
            builder.Services.AddTransient<IBaseRepository<Genre, int>, GenreRepository>();
            builder.Services.AddTransient<IBaseRepository<Category, int>, CategoryRepository>();
            builder.Services.AddTransient<IBaseRepository<Book, Guid>, BookRepository>();
            builder.Services.AddTransient<IBaseRepository<Reader, Guid>, ReaderRepository>();
            builder.Services.AddTransient<IBaseRepository<Issued, Guid>, IssuedRepository>();
            ////////

            // Di Commands
            builder.Services.AddScoped<IReaderCommand, ReaderCommand>();
            builder.Services.AddScoped<IGenreCommand, GenreCommand>();
            builder.Services.AddScoped<ICategoryCommand, CategoryCommand>();
            builder.Services.AddScoped<IIssuedCommand, IssuedCommand>();
            builder.Services.AddScoped<IBookCommand, BookCommand>();
            ////////


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}