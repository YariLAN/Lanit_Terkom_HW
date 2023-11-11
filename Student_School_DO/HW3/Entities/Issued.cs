namespace Entities
{
    public class Issued: IEntity<Issued>
    {
        public Guid IssuedId { get; set; }

        public Guid ReaderId { get; set; }

        public Guid BookId { get; set; }

        public DateTime DateIssue { get; set; }

        public DateTime DateDue { get; set; }

        public Issued() { }

        public Issued(Guid id, Guid reader, Guid book, DateTime issue, DateTime due)
        {
            IssuedId = id;
            ReaderId = reader;
            BookId = book;
            DateIssue = issue;
            DateDue = due;
        }

        public Issued Parse(string s)
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
            return $"{IssuedId} " +
               $"{ReaderId} " +
               $"{BookId} " +
               $"{DateIssue} " +
               $"{DateDue}";
        }
    }
}
