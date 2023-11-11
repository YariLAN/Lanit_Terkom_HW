namespace Entities
{
    public interface IEntity<T>
    {
        public T Parse(string str);
    }
}
