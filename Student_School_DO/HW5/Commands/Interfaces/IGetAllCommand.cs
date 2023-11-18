using Models;

namespace Commands.Interfaces
{
    public interface IGetAllCommand<T>
    {
        public Responce<IEnumerable<T>> GetAll();
    }
}
