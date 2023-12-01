namespace Models
{
    public class CategoryInfo
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<ReaderInfo> Readers { get; set; } = new List<ReaderInfo>();
    }
}
