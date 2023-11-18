using Models;

namespace Commands.Interfaces
{
    public interface IGetByIdCommand<id, T>
    {
        public Responce<T> GetById(id id);
    }
}
