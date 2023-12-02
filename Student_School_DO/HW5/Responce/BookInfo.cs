namespace Models
{
    public class BookInfo
    {
        public Guid BookId { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int GenreId { get; set; }

        public int CollateralValue { get; set; }

        public int RentalCost { get; set; }

        public int CountBook { get; set; }

        public GenreInfo? Genre { get; set; }

        public ICollection<IssuedInfo>? Issueds { get; set; } = new List<IssuedInfo>();
    }
}
