namespace EntitiesEF
{
    public class Book: IEntity<Book>
    {
        public Guid BookId { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int GenreId { get; set; }

        public int CollateralValue { get; set;}

        public int RentalCost { get; set; }

        public int CountBook { get; set; }

        public Genre Genre { get; set; }

        public ICollection<Issued> Issueds { get; set; }

        public Book() { }

        public Book(
            Guid id,
            string name,
            string author,
            int genre_type,
            int collateral,
            int rental,
            int count
        ) {
            BookId = id;
            Name = name;
            Author = author;
            GenreId = genre_type;
            CollateralValue = collateral;
            RentalCost = rental;
            CountBook = count;
        }

        public Book Parse(string str)
        {
            var book = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Book
            (
                id:         Guid.Parse(book[0]),
                name:       book[1],
                author:     book[2],
                genre_type: int.Parse(book[3]),
                collateral: int.Parse(book[4]),
                rental:     int.Parse(book[5]),
                count:      int.Parse(book[6])
            );
        }

        public override string ToString()
        {
            return $"{BookId} " +
                   $"{Name} " +
                   $"{Author} " +
                   $"{GenreId} " +
                   $"{CollateralValue} " +
                   $"{RentalCost} " +
                   $"{CountBook!}";
        }
    }
}