namespace Models
{
    public class IssuedInfo
    {
        public Guid IssuedId { get; set; }

        public Guid ReaderId { get; set; }

        public Guid BookId { get; set; }

        public DateTime DateIssue { get; set; }

        public DateTime DateDue { get; set; }

        public ReaderInfo? Reader { get; set; }

        public BookInfo? Book { get; set; }
    }
}
