using Models;

namespace Commands.Interfaces
{
    public interface IGetAllCommand<T>
    {
        public Response<IEnumerable<T>> GetAll();
    }
}
