namespace Entities
{
    public class Category: IEntity<Category>
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public Category() { }

        public Category(int id, string name)
        {
            CategoryId = id;
            Name = name;
        }

        public Category Parse(string str)
        {
            string?[] item = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (!int.TryParse(item[0], out var res))
            {
                return new Category { Name = item[0] };
            }

            return new Category(int.Parse(item[0]), item[1]);
        }

        public override string ToString()
        {
            return $"{CategoryId} {Name}";
        }
    }
}
