using EntitiesEF;
using Repositories;

namespace hw_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // DI
            builder.Services.AddTransient<IBaseRepository<Genre, int>, GenreRepository>();

            builder.Services.AddTransient<IBaseRepository<Category, int>, CategoryRepository>();

            builder.Services.AddTransient<IBaseRepository<Book, Guid>, BookRepository>();

            builder.Services.AddTransient<IBaseRepository<Reader, Guid>, ReaderRepository>();

            builder.Services.AddTransient<IBaseRepository<Issued, Guid>, IssuedRepository>();
            ////////

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}