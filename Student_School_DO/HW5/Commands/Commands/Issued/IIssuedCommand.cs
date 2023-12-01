using Commands.Interfaces;
using Models;

namespace Commands.Commands.Issued
{
    public interface IIssuedCommand :
        ICreateCommand<IssuedInfo, Guid>,
        IUpdateCommand<IssuedInfo, Guid>,
        IGetAllCommand<IssuedInfo>,
        IGetByIdCommand<Guid, IssuedInfo>,
        IDeleteCommand<Guid>
    {

    }
}
