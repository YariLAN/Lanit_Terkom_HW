using Commands.Interfaces;
using Models;

namespace Commands.Commands.Category
{
    public interface ICategoryCommand :
        ICreateCommand<CategoryInfo, int>,
        IUpdateCommand<CategoryInfo, int>,
        IGetAllCommand<CategoryInfo>,
        IGetByIdCommand<int, CategoryInfo>,
        IDeleteCommand<int>
    {

    }
}
