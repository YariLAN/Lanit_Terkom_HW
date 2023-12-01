namespace Models
{
    public class GenreInfo
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public ICollection<BookInfo>? Books { get; set; } = new List<BookInfo>();
    }
}
