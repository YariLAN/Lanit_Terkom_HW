namespace Provider
{
    public interface IRepository<T, identificatory>
    {
        public List<T> GetAll();

        public T GetById(identificatory id);

        public void AddItem(T entity);

        public void UpdateItem(T entity);

        public void DeleteById(identificatory id);
    }
}
