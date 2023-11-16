using Entities;

namespace Provider
{
    public class CategoryRepository : IRepository<Category, int>
    {
        LibraryDB _db = new LibraryDB();

        private const string GET_ALL_SQL = @"SELECT * FROM categories";

        private const string GET_BY_ID_SQL =
            @"SELECT * FROM categories WHERE id_category = {0}";

        private const string ADD_SQL =
            @"INSERT INTO categories VALUES ('{0}');";

        private const string DELETE_SQL =
            @"DELETE FROM categories WHERE id_category = {0}";

        private const string UPDATE_SQL =
            @"UPDATE categories
            SET name = '{1}'
            WHERE id_category = {0}";

        public List<Category> GetAll()
        {
            var category = new Category();
            var categoryList = new List<Category>();

            var str = _db.GetQuery(GET_ALL_SQL, 2);

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                categoryList.Add(category.Parse(line));
            }

            return categoryList;
        }

        public Category GetById(int id)
        {
            var category = new Category();

            var str =  _db.GetQuery(string.Format(GET_BY_ID_SQL, id.ToString()), 2);

            return category.Parse(str);
        }

        public void AddItem(Category category)
        {
            _db.AddQuery(ADD_SQL, category.Name);
        }

        public void UpdateItem(Category category)
        {
            _db.UpdateQuery(UPDATE_SQL, category.CategoryId.ToString(), category.Name);
        }

        public void DeleteById(int id)
        {
            _db.DeleteQuery(DELETE_SQL, id.ToString());
        }
    }
}
