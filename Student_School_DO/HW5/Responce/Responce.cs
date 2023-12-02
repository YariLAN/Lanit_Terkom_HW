namespace Models
{
    public class Responce<T>
    {
        public T Value { get; set; }

        public List<string> Messages {get; set;}
    }
}