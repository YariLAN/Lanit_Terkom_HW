using Models;

namespace Commands.Interfaces
{
    public interface IDeleteCommand<T>
    {
        public Response<T> Delete(T id);
    }
}
