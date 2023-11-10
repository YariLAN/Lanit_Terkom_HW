using Entities;

namespace Provider
{
    public class BookRepository: IRepository<Book, Guid>
    {
        LibraryDB _db = new LibraryDB();

        private const string GET_ALL_SQL = @"SELECT * FROM books";

        private const string GET_BY_ID_SQL =
            @"SELECT * FROM books WHERE id_book = '{0}'";

        private const string ADD_SQL =
            @"INSERT INTO books VALUES ('{0}', '{1}', '{2}', {3}, {4}, {5}, {6});";

        private const string DELETE_SQL =
            @"DELETE FROM books WHERE id_book = '{0}'";

        private const string UPDATE_SQL =
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
            var book = new Book();

            var bookList = new List<Book>();

            var str = _db.GetQuery(GET_ALL_SQL, 7);

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                bookList.Add(book.Parse(line));
            }

            return bookList;
        }

        public Book GetById(Guid id)
        {
            var book = new Book();

            var str = _db.GetQuery(string.Format(GET_BY_ID_SQL, id), 7);

            return book.Parse(str);
        }

        public void AddItem(Book entity)
        {
            _db.AddQuery(
                ADD_SQL,
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
            _db.UpdateQuery(
                UPDATE_SQL,
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
            _db.DeleteQuery(DELETE_SQL, id.ToString());
        }
    }
}
