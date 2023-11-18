using Models;

namespace Commands.Interfaces
{
    public interface ICreateCommand<T, id>
    {
        public Responce<id> Create(T entity);
    }
}
