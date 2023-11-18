using Commands.Interfaces;
using Models;

namespace Commands.Commands.Category
{
    public interface ICategoryCommand :
        ICreateCommand<CategoryModel, int>,
        IUpdateCommand<CategoryModel, int>,
        IGetAllCommand<CategoryModel>,
        IGetByIdCommand<int, CategoryModel>,
        IDeleteCommand<int>
    {

    }
}
