using EntitiesEF;
using Microsoft.EntityFrameworkCore;
using ProviderEF;

namespace Repositories
{
    public class CategoryRepository : IBaseRepository<Category, int>
    {
        private LibraryDB _db;

        public CategoryRepository()
        {
            _db = new LibraryDB();
        }

        public void AddItem(Category entity)
        {
            _db.Categories.Add(entity);

            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var category = GetById(id);

            _db.Categories.Remove(category);

            _db.SaveChanges();
        }

        public List<Category> GetAll() => _db.Categories.AsNoTracking().ToList();

        public Category? GetById(int id)
        {
            var cat = _db.Categories
                        .Include(c => c.Readers)
                        .FirstOrDefault(b => b.CategoryId == id);
            return cat;
        }

        public void UpdateItem(Category entity)
        {
            _db.Categories.Update(entity);

            _db.SaveChanges();
        }
    }
}
