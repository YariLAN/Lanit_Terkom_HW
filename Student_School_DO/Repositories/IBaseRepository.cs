namespace Repositories
{
    public interface IBaseRepository<T, identificator>
    {
        public List<T> GetAll();

        public T? GetById(identificator id);

        public void AddItem(T entity);

        public void UpdateItem(T entity);

        public void DeleteById(identificator id);
    }
}