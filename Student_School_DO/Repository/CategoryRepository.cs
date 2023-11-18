﻿using Entities;

namespace Provider
{
    public class CategoryRepository: InterfaceRepository<Category, int>
    {
        LibraryDB db = new LibraryDB();

        private const string GET_ALL = @"SELECT * FROM categories";

        private const string GET_BY_ID =
            @"SELECT * FROM categories WHERE id_category = {0}";

        private const string ADD =
            @"INSERT INTO categories VALUES ('{0}');";

        private const string DELETE =
            @"DELETE FROM categories WHERE id_category = {0}";

        private const string UPDATE =
            @"UPDATE categories
            SET name = '{1}'
            WHERE id_category = {0}";

        public List<Category> GetAll()
        {
            var cat = new Category();
            var listC = new List<Category>();

            var str = db.GetQuery(GET_ALL, 2);

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                listC.Add(cat.Parse(line));
            }

            return listC;
        }

        public Category GetById(int id)
        {
            var cat = new Category();

            var str =  db.GetQuery(string.Format(GET_BY_ID, id.ToString()), 2);

            return cat.Parse(str);
        }

        public void AddItem(Category c)
        {
            db.AddQuery(ADD, c.Name);
        }

        public void UpdateItem(Category c)
        {
            db.UpdateQuery(UPDATE, c.CategoryId.ToString(), c.Name);
        }

        public void DeleteById(int id)
        {
            db.DeleteQuery(DELETE, id.ToString());
        }
    }
}
