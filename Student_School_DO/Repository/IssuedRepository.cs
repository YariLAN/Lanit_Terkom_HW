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
                entity.id_issued.ToString(),
                entity.fk_id_reader.ToString(),
                entity.fk_id_book.ToString(),
                entity.date_issue.ToString(),
                entity.date_due.ToString()
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

            var str = db.GetQuery(
                GET_ALL,
                nameof(i.id_issued),
                nameof(i.fk_id_reader),
                nameof(i.fk_id_book),
                nameof(i.date_issue),
                nameof(i.date_due)
            );

            str = str.Replace("0:00:00", " ");

            var list = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in list)
            {
                listIssued.Add(Issued.Parse(line));
            }

            return listIssued;
        }

        public Issued GetById(Guid id)
        {
            var i = new Issued();

            return Issued.Parse(
                db.GetQuery(
                    string.Format(GET_BY_ID, id.ToString()),
                    nameof(i.id_issued),
                    nameof(i.fk_id_reader),
                    nameof(i.fk_id_book),
                    nameof(i.date_issue),
                    nameof(i.date_due))
                );
        }

        public void UpdateItem(Issued entity)
        {
            db.UpdateQuery(
                UPDATE,
                entity.id_issued.ToString(),
                entity.fk_id_reader.ToString(),
                entity.fk_id_book.ToString(),
                entity.date_issue.ToString(),
                entity.date_due.ToString()
            );
        }
    }
}
