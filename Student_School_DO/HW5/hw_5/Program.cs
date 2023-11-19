using EntitiesEF;
using Repositories;
using System.Text.Json.Serialization;

using Commands.Commands.Book;
using Commands.Commands.Category;
using Commands.Commands.Genre;
using Commands.Commands.Issued;
using Commands.Commands.Reader;

using Validation.Book;
using Validation.Category;
using Validation.Genre;
using Validation.Reader;

using Validation.Book.Interfaces;
using Validation.Genre.Interfaces;
using Validation.Category.Interfaces;
using Validation.Reader.Interfaces;

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
            builder.Services.AddTransient<IReaderCommand, ReaderCommand>();
            builder.Services.AddTransient<IGenreCommand, GenreCommand>();
            builder.Services.AddTransient<ICategoryCommand, CategoryCommand>();
            builder.Services.AddTransient<IIssuedCommand, IssuedCommand>();
            builder.Services.AddTransient<IBookCommand, BookCommand>();
            ////////

            // Di Validators
            builder.Services.AddTransient<ICreateGenreModelValidator, CreateGenreModelValidator>();
            builder.Services.AddTransient<ICreateBookModelValidator, CreateBookModelValidator>();
            builder.Services.AddTransient<ICreateReaderModelValidator, CreateReaderModelValidator>();
            builder.Services.AddTransient<ICreateCategoryModelValidator, CreateCategoryModelValidator>();
            ////////

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}