namespace EntitiesEF
{
    public interface IEntity<T>
    {
        public T Parse(string str);
    }
}
