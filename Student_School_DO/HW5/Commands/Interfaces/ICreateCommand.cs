using Models;

namespace Commands.Interfaces
{
    public interface ICreateCommand<T, id>
    {
        public Response<id> Create(T entity);
    }
}
