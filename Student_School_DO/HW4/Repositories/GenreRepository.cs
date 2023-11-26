using EntitiesEF;
using Microsoft.EntityFrameworkCore;
using ProviderEF;

namespace Repositories
{
    public class GenreRepository : IBaseRepository<Genre, int>
    {
        private LibraryDB _db;

        public GenreRepository()
        {
            _db = new LibraryDB();
        }

        public void AddItem(Genre entity)
        {
            _db.Genres.Add(entity);

            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var genre = GetById(id);

            _db.Genres.Remove(genre);

            _db.SaveChanges();
        }

        public List<Genre> GetAll() => _db.Genres.AsNoTracking().ToList();

        public Genre? GetById(int id)
        {
            return _db.Genres.FirstOrDefault(b => b.GenreId == id);
        }

        public void UpdateItem(Genre entity)
        {
            _db.Genres.Update(entity);

            _db.SaveChanges();
        }
    }
}
