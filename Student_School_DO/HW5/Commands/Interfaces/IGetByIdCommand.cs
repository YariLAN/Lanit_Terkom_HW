using Models;

namespace Commands.Interfaces
{
    public interface IGetByIdCommand<id, T>
    {
        public Response<T> GetById(id id);
    }
}
