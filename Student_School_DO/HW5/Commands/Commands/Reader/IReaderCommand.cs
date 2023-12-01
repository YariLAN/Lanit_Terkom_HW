using Commands.Interfaces;
using Models;

namespace Commands.Commands.Reader
{
    public interface IReaderCommand :
        ICreateCommand<ReaderInfo, Guid>,
        IUpdateCommand<ReaderInfo, Guid>,
        IGetAllCommand<ReaderInfo>,
        IGetByIdCommand<Guid,  ReaderInfo>,
        IDeleteCommand<Guid>
    {

    }
}
