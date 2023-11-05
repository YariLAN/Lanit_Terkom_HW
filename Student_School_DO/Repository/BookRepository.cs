using Entities;

namespace Provider
{
    public class BookRepository: InterfaceRepository<Book, Guid>
    {
        LibraryDB db = new LibraryDB();

        private const string GET_ALL = @"SELECT * FROM books";

        private const string GET_BY_ID =
            @"SELECT * FROM books WHERE id_book = '{0}'";

        private const string ADD =
            @"INSERT INTO books VALUES ('{0}', '{1}', '{2}', {3}, {4}, {5}, {6});";

        private const string DELETE =
            @"DELETE FROM books WHERE id_book = '{0}'";

        private const string UPDATE =
            @"UPDATE books
            SET nameBook = '{1}',
                author = '{2}',
                fk_id_genre = {3},
                collateralValue = {4},
                rentalCost = {5},
                countBook = {6}
            WHERE id_book = '{0}';";

        public List<Book> GetAll()
        {
            var b = new Book();

            var listBook = new List<Book>();

            var str = db.GetQuery(GET_ALL, 7);

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                listBook.Add(new Book().Parse(line));
            }

            return listBook;
        }

        public Book GetById(Guid id)
        {
            var b = new Book();

            var str = db.GetQuery(string.Format(GET_BY_ID, id), 7);

            return b.Parse(str);
        }

        public void AddItem(Book entity)
        {
            db.AddQuery(
                ADD,
                entity.BookId.ToString(),
                entity.Name,
                entity.Author,
                entity.GenreId.ToString(),
                entity.CollateralValue.ToString(),
                entity.RentalCost.ToString(),
                entity.CountBook.ToString());
        }

        public void UpdateItem(Book entity)
        {
            db.UpdateQuery(
                UPDATE,
                entity.BookId.ToString(),
                entity.Name,
                entity.Author,
                entity.GenreId.ToString(),
                entity.CollateralValue.ToString(),
                entity.RentalCost.ToString(),
                entity.CountBook.ToString());
        }

        public void DeleteById(Guid id)
        {
            db.DeleteQuery(DELETE, id.ToString());
        }
    }
}
