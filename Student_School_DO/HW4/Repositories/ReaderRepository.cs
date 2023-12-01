using EntitiesEF;
using Microsoft.EntityFrameworkCore;
using ProviderEF;

namespace Repositories
{
    public class ReaderRepository : IBaseRepository<Reader, Guid>
    {
        private LibraryDB _db;

        public ReaderRepository()
        {
            _db = new LibraryDB();
        }

        public void AddItem(Reader entity)
        {
            _db.Readers.Add(entity);

            _db.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var reader = GetById(id);

            _db.Readers.Remove(reader);

            _db.SaveChanges();
        }

        public List<Reader> GetAll() => _db.Readers.AsNoTracking().ToList();

        public Reader? GetById(Guid id)
        {
            return _db.Readers
                    .Include(r => r.Category)
                    .Include(r => r.Issueds)
                    .FirstOrDefault(b => b.ReaderId == id);
        }

        public void UpdateItem(Reader entity)
        {
            _db.Readers.Update(entity);

            _db.SaveChanges();
        }
    }
}
