using Models;

namespace Commands.Interfaces
{
    public interface IDeleteCommand<T>
    {
        public Responce<T> Delete(T id);
    }
}
