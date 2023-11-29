namespace Models.Response.Category
{
    public class CreateCategoryResponse
    {
        public CategoryModel Category { get; set; }

        public string? Error { get; set; }
    }
}
