namespace Entities
{
    public class Genre
    {
        public int id_genre;

        public string nameGenre;

        public Genre() { }

        public Genre(int id, string name)
        {
            id_genre = id;

            nameGenre = name;
        }

        public static Genre Parse(string genre)
        {
            var str = genre.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Genre(int.Parse(str[0]), str[1]);
        }

        public override string ToString()
        {
            return $"{id_genre} {nameGenre}";
        }
    }
}
