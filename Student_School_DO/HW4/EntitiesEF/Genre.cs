using System.Text.Json.Serialization;

namespace EntitiesEF
{
    public class Genre : IEntity<Genre>
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Genre() { }

        public Genre(int id, string name)
        {
            GenreId = id;
            Name = name;
        }

        public Genre Parse(string genre)
        {
            var str = genre.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (!int.TryParse(str[0], out var res))
            {
                return new Genre { Name = str[0] };
            }

            return new Genre(int.Parse(str[0]), str[1]);
        }

        public override string ToString()
        {
            return $"{GenreId} {Name}";
        }
    }
}
