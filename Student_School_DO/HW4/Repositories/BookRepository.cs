using EntitiesEF;
using Microsoft.EntityFrameworkCore;
using ProviderEF;

namespace Repositories
{
    public class BookRepository : IBaseRepository<Book, Guid>
    {
        private LibraryDB _db;

        public BookRepository()
        {
            _db = new LibraryDB();
        }

        public void AddItem(Book entity)
        {
            _db.Books.Add(entity);

            _db.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var book = GetById(id);

            _db.Books.Remove(book);

            _db.SaveChanges();
        }

        public List<Book> GetAll() => _db.Books.AsNoTracking().ToList();

        public Book? GetById(Guid id)
        {
            return _db.Books.FirstOrDefault(b => b.BookId == id);
        }

        public void UpdateItem(Book entity)
        {
            _db.Books.Update(entity);

            _db.SaveChanges();
        }
    }
}
