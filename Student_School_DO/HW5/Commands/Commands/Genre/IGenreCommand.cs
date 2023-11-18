using Commands.Interfaces;
using Models;

namespace Commands.Commands.Genre
{
    public interface IGenreCommand :
        ICreateCommand<GenreModel, int>,
        IUpdateCommand<GenreModel, int>,
        IGetAllCommand<GenreModel>,
        IGetByIdCommand<int, GenreModel>,
        IDeleteCommand<int>
    {

    }
}
