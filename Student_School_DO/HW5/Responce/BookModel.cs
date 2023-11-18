namespace Models
{
    public class BookModel
    {
        public Guid BookId { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int GenreId { get; set; }

        public int CollateralValue { get; set; }

        public int RentalCost { get; set; }

        public int CountBook { get; set; }

        public GenreModel? Genre { get; set; }

        public ICollection<IssuedModel>? Issueds { get; set; } = new List<IssuedModel>();
    }
}
