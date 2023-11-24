using Entities;

namespace Provider
{
    public class ReaderRepository: InterfaceRepository<Reader, Guid>
    {
        private LibraryDB db = new LibraryDB();

        private const string GET_ALL = @"SELECT * FROM readers;";

        private const string GET_BY_ID =
            @"SELECT * FROM readers WHERE id_reader = '{0}';";

        private const string ADD =
            @"INSERT INTO readers VALUES ('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}');";

        private const string DELETE =
            @"DELETE FROM readers WHERE id_reader = '{0}';";

        private const string UPDATE =
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
            var listReader = new List<Reader>();

            var reader = new Reader();

            var str = db.GetQuery(GET_ALL, 7);

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                listReader.Add(reader.Parse(line));
            }

            return listReader;
        }

        public Reader GetById(Guid id)
        {
            var reader = new Reader();

            string str = db.GetQuery(string.Format(GET_BY_ID, id), 7);

            return reader.Parse(str);
        }

        public void AddItem(Reader reader)
        {
            db.AddQuery(ADD,
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
            db.UpdateQuery(UPDATE,
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
            db.DeleteQuery(DELETE, id.ToString());
        }
    }
}
