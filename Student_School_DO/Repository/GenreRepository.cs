using Entities;

namespace Provider
{
    public class GenreRepository : InterfaceRepository<Genre, int>
    {
        LibraryDB db = new LibraryDB();

        private const string GET_ALL = @"SELECT * FROM genre_type";

        private const string GET_BY_ID =
            @"SELECT * FROM genre_type WHERE id_genre = {0}";

        private const string ADD =
            @"INSERT INTO genre_type VALUES ('{0}');";

        private const string DELETE =
            @"DELETE FROM genre_type WHERE id_genre = {0}";

        private const string UPDATE =
            @"UPDATE genre_type
            SET nameGenre = '{1}'
            WHERE id_genre = {0}";

        public void AddItem(Genre entity)
        {
            db.AddQuery(ADD, entity.Name);
        }

        public void DeleteById(int id)
        {
            db.DeleteQuery(DELETE, id.ToString());
        }

        public List<Genre> GetAll()
        {
            var gen = new Genre();

            var listG = new List<Genre>();

            var str = db.GetQuery(GET_ALL, 2);

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                listG.Add(gen.Parse(line));
            }

            return listG;
        }

        public Genre GetById(int id)
        {
            var gen = new Genre();

            var str = db.GetQuery(string.Format(GET_BY_ID, id.ToString()), 2);

            return gen.Parse(str);
        }

        public void UpdateItem(Genre g)
        {
            db.UpdateQuery(UPDATE, g.GenreId.ToString(), g.Name);
        }
    }
}
