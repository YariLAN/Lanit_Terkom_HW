using Commands.Interfaces;
using Models;

namespace Commands.Commands.Genre
{
    public interface IGenreCommand :
        ICreateCommand<GenreInfo, int>,
        IUpdateCommand<GenreInfo, int>,
        IGetAllCommand<GenreInfo>,
        IGetByIdCommand<int, GenreInfo>,
        IDeleteCommand<int>
    {

    }
}
