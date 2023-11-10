using Entities;

namespace Provider
{
    public class GenreRepository : IRepository<Genre, int>
    {
        LibraryDB _db = new LibraryDB();

        private const string GET_ALL_SQL = @"SELECT * FROM genre_type";

        private const string GET_BY_ID_SQL =
            @"SELECT * FROM genre_type WHERE id_genre = {0}";

        private const string ADD_SQL =
            @"INSERT INTO genre_type VALUES ('{0}');";

        private const string DELETE_SQL =
            @"DELETE FROM genre_type WHERE id_genre = {0}";

        private const string UPDATE_SQL =
            @"UPDATE genre_type
            SET nameGenre = '{1}'
            WHERE id_genre = {0}";

        public void AddItem(Genre entity)
        {
            _db.AddQuery(ADD_SQL, entity.Name);
        }

        public void DeleteById(int id)
        {
            _db.DeleteQuery(DELETE_SQL, id.ToString());
        }

        public List<Genre> GetAll()
        {
            var genre = new Genre();

            var genreList = new List<Genre>();

            var str = _db.GetQuery(GET_ALL_SQL, 2);

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                genreList.Add(genre.Parse(line));
            }

            return genreList;
        }

        public Genre GetById(int id)
        {
            var genre = new Genre();

            var str = _db.GetQuery(string.Format(GET_BY_ID_SQL, id.ToString()), 2);

            return genre.Parse(str);
        }

        public void UpdateItem(Genre entity)
        {
            _db.UpdateQuery(UPDATE_SQL, entity.GenreId.ToString(), entity.Name);
        }
    }
}
