﻿namespace Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<ReaderModel> Readers { get; set; } = new List<ReaderModel>();
    }
}
