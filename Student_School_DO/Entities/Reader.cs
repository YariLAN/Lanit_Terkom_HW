namespace Entities
{
    public class Reader: IEntity<Reader>
    {
        public Guid ReaderId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public int CategoryId { get; set; }

        public string Adress { get; set; }

        public string Email { get; set; }

        public Reader() { }

        public Reader(
            Guid id,
            string last,
            string first,
            string patronymic,
            int category,
            string adress,
            string email)
        {
            ReaderId = id;
            LastName = last;
            FirstName = first;
            Patronymic = patronymic;
            CategoryId = category;
            Adress = adress;
            Email = email;
        }

        public Reader Parse(string str)
        {
            string[] items = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Reader
             (
                id:         Guid.Parse(items[0]),
                last:       items[1],
                first:      items[2],
                patronymic: items[3],
                category:   int.Parse(items[4]),
                adress:     items[5],
                email:      items[6]
            );
        }

        public override string ToString()
        {
            return $"{ReaderId} " +
                   $"{LastName} " +
                   $"{FirstName} " +
                   $"{Patronymic} " +
                   $"{CategoryId} " +
                   $"{Adress} " +
                   $"{Email!}";
        }
    }
}
