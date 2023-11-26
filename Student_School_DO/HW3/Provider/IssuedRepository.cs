using Entities;

namespace Provider
{
    public class IssuedRepository : IRepository<Issued, Guid>
    {
        LibraryDB _db = new LibraryDB();

        private const string GET_ALL_SQL = @"SELECT * FROM issued";

        private const string GET_BY_ID_SQL =
            @"SELECT * FROM issued WHERE id_issued = '{0}'";

        private const string ADD_SQL =
            @"INSERT INTO issued VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');";

        private const string DELETE_SQL =
            @"DELETE FROM issued WHERE id_issued = '{0}'";

        private const string UPDATE_SQL =
            @"UPDATE issued
            SET fk_id_reader = '{1}',
                fk_id_book = '{2}',
                date_issue = '{3}',
                date_due = '{4}'
            WHERE id_issued = '{0}'";

        public void AddItem(Issued entity)
        {
            _db.AddQuery(
                ADD_SQL,
                entity.IssuedId.ToString(),
                entity.ReaderId.ToString(),
                entity.BookId.ToString(),
                entity.DateIssue.ToString(),
                entity.DateDue.ToString()
            );
        }

        public void DeleteById(Guid id)
        {
            _db.DeleteQuery(DELETE_SQL, id.ToString());
        }

        public List<Issued> GetAll()
        {
            var issued = new Issued();
            var issuedList = new List<Issued>();

            var str = _db.GetQuery(GET_ALL_SQL, 5);

            str = str.Replace("0:00:00", " ");

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                issuedList.Add(issued.Parse(line));
            }

            return issuedList;
        }

        public Issued GetById(Guid id)
        {
            var i = new Issued();

            return i.Parse(
                _db.GetQuery(string.Format(GET_BY_ID_SQL, id.ToString()), 5));
        }

        public void UpdateItem(Issued entity)
        {
            _db.UpdateQuery(
                UPDATE_SQL,
                entity.IssuedId.ToString(),
                entity.ReaderId.ToString(),
                entity.BookId.ToString(),
                entity.DateIssue.ToString(),
                entity.DateDue.ToString()
            );
        }
    }
}
