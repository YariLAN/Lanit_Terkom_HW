namespace Models
{
    public class Response<T>
    {
        public T Value { get; set; }

        public List<string> Messages {get; set;}
    }
}