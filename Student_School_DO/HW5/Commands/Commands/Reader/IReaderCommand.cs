using Commands.Interfaces;
using Models;

namespace Commands.Commands.Reader
{
    public interface IReaderCommand :
        ICreateCommand<ReaderModel, Guid>,
        IUpdateCommand<ReaderModel, Guid>,
        IGetAllCommand<ReaderModel>,
        IGetByIdCommand<Guid,  ReaderModel>,
        IDeleteCommand<Guid>
    {

    }
}
