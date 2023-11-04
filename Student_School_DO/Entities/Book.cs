namespace Entities
{
    public class Book
    {
        public Guid id_book { get; set; }

        public string nameBook { get; set; }

        public string author { get; set; }

        public int fk_id_genre { get; set; }

        public int collateralValue { get; set;}

        public int rentalCost { get; set; }

        public int countBook { get; set; }

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
            id_book = id;

            nameBook = name;

            this.author = author;

            fk_id_genre = genre_type;

            collateralValue = collateral;

            rentalCost = rental;

            countBook = count;
        }

        public static Book Parse(string str)
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
            return $"{id_book} " +
                   $"{nameBook} " +
                   $"{author} " +
                   $"{fk_id_genre} " +
                   $"{collateralValue} " +
                   $"{rentalCost} " +
                   $"{countBook!}";
        }
    }
}