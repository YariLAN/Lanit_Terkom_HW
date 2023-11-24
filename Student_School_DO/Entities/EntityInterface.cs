namespace Entities
{
    public interface EntityInterface<T>
    {
        public T Parse(string str);
    }
}
