using EntitiesEF;
using Microsoft.EntityFrameworkCore;
using ProviderEF;

namespace Repositories
{
    public class IssuedRepository : IBaseRepository<Issued, Guid>
    {
        private LibraryDB _db;

        public IssuedRepository()
        {
            _db = new LibraryDB();
        }

        public void AddItem(Issued entity)
        {
            _db.Issueds.Add(entity);

            _db.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var issued = GetById(id);

            _db.Issueds.Remove(issued);

            _db.SaveChanges();
        }

        public List<Issued> GetAll() => _db.Issueds.AsNoTracking().ToList();

        public Issued? GetById(Guid id)
        {
            return _db.Issueds.FirstOrDefault(b => b.IssuedId == id);
        }

        public void UpdateItem(Issued entity)
        {
            _db.Issueds.Update(entity);

            _db.SaveChanges();
        }
    }
}
