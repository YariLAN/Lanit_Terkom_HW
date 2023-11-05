using Entities;

namespace Provider
{
    public class IssuedRepository : InterfaceRepository<Issued, Guid>
    {
        LibraryDB db = new LibraryDB();

        private const string GET_ALL = @"SELECT * FROM issued";

        private const string GET_BY_ID =
            @"SELECT * FROM issued WHERE id_issued = '{0}'";

        private const string ADD =
            @"INSERT INTO issued VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');";

        private const string DELETE =
            @"DELETE FROM issued WHERE id_issued = '{0}'";

        private const string UPDATE =
            @"UPDATE issued
            SET fk_id_reader = '{1}',
                fk_id_book = '{2}',
                date_issue = '{3}',
                date_due = '{4}'
            WHERE id_issued = '{0}'";

        public void AddItem(Issued entity)
        {
            db.AddQuery(
                ADD,
                entity.IssuedId.ToString(),
                entity.ReaderId.ToString(),
                entity.BookId.ToString(),
                entity.DateIssue.ToString(),
                entity.DateDue.ToString()
            );
        }

        public void DeleteById(Guid id)
        {
            db.DeleteQuery(DELETE, id.ToString());
        }

        public List<Issued> GetAll()
        {
            var listIssued = new List<Issued>();

            var i = new Issued();

            var str = db.GetQuery(GET_ALL, 5);

            str = str.Replace("0:00:00", " ");

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                listIssued.Add(i.Parse(line));
            }

            return listIssued;
        }

        public Issued GetById(Guid id)
        {
            var i = new Issued();

            return i.Parse(
                db.GetQuery(string.Format(GET_BY_ID, id.ToString()), 5));
        }

        public void UpdateItem(Issued entity)
        {
            db.UpdateQuery(
                UPDATE,
                entity.IssuedId.ToString(),
                entity.ReaderId.ToString(),
                entity.BookId.ToString(),
                entity.DateIssue.ToString(),
                entity.DateDue.ToString()
            );
        }
    }
}
