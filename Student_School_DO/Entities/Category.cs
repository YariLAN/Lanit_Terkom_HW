using System.Reflection.Metadata.Ecma335;

namespace Entities
{
    public class Category
    {
        public int id_category { get; set; }

        public string name { get; set; }

        public Category() { }

        public Category(int id, string name)
        {
            id_category = id;

            this.name = name;
        }

        public static Category Parse(string str)
        {
            string?[] item = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Category(int.Parse(item[0]), item[1]);
        }

        public override string ToString()
        {
            return $"{id_category} {name}";
        }
    }
}
