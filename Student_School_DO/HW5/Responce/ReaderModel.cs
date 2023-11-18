namespace Models
{
    public class ReaderModel
    {
        public Guid ReaderId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public int CategoryId { get; set; }

        public string Adress { get; set; }

        public string Email { get; set; }

        public CategoryModel? Category { get; set; }

        public ICollection<IssuedModel>? Issueds { get; set; } = new List<IssuedModel>();
    }
}
