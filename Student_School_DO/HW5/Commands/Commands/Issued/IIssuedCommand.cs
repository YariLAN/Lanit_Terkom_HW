using Commands.Interfaces;
using Models;

namespace Commands.Commands.Issued
{
    public interface IIssuedCommand :
        ICreateCommand<IssuedModel, Guid>,
        IUpdateCommand<IssuedModel, Guid>,
        IGetAllCommand<IssuedModel>,
        IGetByIdCommand<Guid, IssuedModel>,
        IDeleteCommand<Guid>
    {

    }
}
