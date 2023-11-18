namespace Models
{
    public class IssuedModel
    {
        public Guid IssuedId { get; set; }

        public Guid ReaderId { get; set; }

        public Guid BookId { get; set; }

        public DateTime DateIssue { get; set; }

        public DateTime DateDue { get; set; }

        public ReaderModel? Reader { get; set; }

        public BookModel? Book { get; set; }
    }
}
