namespace Models
{
    public class Response<T>
    {
        public T Value { get; set; }

        public List<string> Errors {get; set;}
    }
}