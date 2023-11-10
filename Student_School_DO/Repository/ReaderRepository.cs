using Entities;

namespace Provider
{
    public class ReaderRepository: IRepository<Reader, Guid>
    {
        private LibraryDB _db = new LibraryDB();

        private const string GET_ALL_SQL = @"SELECT * FROM readers;";

        private const string GET_BY_ID_SQL =
            @"SELECT * FROM readers WHERE id_reader = '{0}';";

        private const string ADD_SQL =
            @"INSERT INTO readers VALUES ('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}');";

        private const string DELETE_SQL =
            @"DELETE FROM readers WHERE id_reader = '{0}';";

        private const string UPDATE_SQL =
            @"UPDATE readers
            SET lastName = '{1}',
                firstName = '{2}',
                patronymic = '{3}',
                fk_id_category = {4},
                adress = '{5}',
                email = '{6}'
            WHERE id_reader = '{0}'";

        public List<Reader> GetAll()
        {
            var readerList = new List<Reader>();
            var reader = new Reader();

            var str = _db.GetQuery(GET_ALL_SQL, 7);

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                readerList.Add(reader.Parse(line));
            }

            return readerList;
        }

        public Reader GetById(Guid id)
        {
            var reader = new Reader();

            string str = _db.GetQuery(string.Format(GET_BY_ID_SQL, id), 7);

            return reader.Parse(str);
        }

        public void AddItem(Reader reader)
        {
            _db.AddQuery(ADD_SQL,
                reader.ReaderId.ToString(),
                reader.LastName,
                reader.FirstName,
                reader.Patronymic,
                reader.CategoryId.ToString(),
                reader.Adress,
                reader.Email);
        }

        public void UpdateItem(Reader reader)
        {
            _db.UpdateQuery(UPDATE_SQL,
                reader.ReaderId.ToString(),
                reader.LastName,
                reader.FirstName,
                reader.Patronymic,
                reader.CategoryId.ToString(),
                reader.Adress,
                reader.Email);
        }

        public void DeleteById(Guid id)
        {
            _db.DeleteQuery(DELETE_SQL, id.ToString());
        }
    }
}
