namespace Models
{
    public class GenreModel
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public ICollection<BookModel>? Books { get; set; } = new List<BookModel>();
    }
}
