namespace Entities
{
    public class Reader
    {
        public Guid id_reader { get; set; }

        public string lastName { get; set; }

        public string firstName { get; set; }

        public string patronymic { get; set; }

        public int fk_id_category { get; set; }

        public string adress { get; set; }

        public string email { get; set; }

        public Reader() { }

        public Reader(
            Guid id,
            string last,
            string first,
            string patronymic,
            int category,
            string adress,
            string email
        ) {
            id_reader = id;

            lastName = last;

            firstName = first;

            this.patronymic = patronymic;

            fk_id_category = category;

            this.adress = adress;

            this.email = email;
        }

        public static Reader Parse(string str)
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
            return $"{id_reader} " +
                   $"{lastName} " +
                   $"{firstName} " +
                   $"{patronymic} " +
                   $"{fk_id_category} " +
                   $"{adress} " +
                   $"{email!}";
        }
    }
}
