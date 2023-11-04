namespace Entities
{
    public class Issued
    {
        public Guid id_issued { get; set; }

        public Guid fk_id_reader { get; set; }

        public Guid fk_id_book { get; set; }

        public DateTime date_issue { get; set; }

        public DateTime date_due { get; set; }

        public Issued() { }

        public Issued(Guid id, Guid reader, Guid book, DateTime issue, DateTime due)
        {
            id_issued = id;

            fk_id_reader = reader;

            fk_id_book = book;

            date_issue = issue;

            date_due = due;
        }

        public static Issued Parse(string s)
        {
            var items = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Issued
            (
                id:     Guid.Parse(items[0]),
                reader: Guid.Parse(items[1]),
                book:   Guid.Parse(items[2]),
                issue:  DateTime.Parse(items[3]),
                due:    DateTime.Parse(items[4])
            );
        }

        public override string ToString()
        {
            return $"{id_issued} " +
               $"{fk_id_reader} " +
               $"{fk_id_book} " +
               $"{date_issue} " +
               $"{date_due}";
        }
    }
}
