using Models;

namespace Commands.Interfaces
{
    public interface IUpdateCommand<T, id>
    {
        public Response<id> Update(id id, T entity);
    }
}
