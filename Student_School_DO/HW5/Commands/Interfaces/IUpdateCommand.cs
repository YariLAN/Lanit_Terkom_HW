using Models;

namespace Commands.Interfaces
{
    public interface IUpdateCommand<T, id>
    {
        public Responce<id> Update(id id, T entity);
    }
}
