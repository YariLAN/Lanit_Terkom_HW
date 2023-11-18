using AutoMapper;
using Azure.Core;
using Models;
using Repositories;

namespace Commands.Commands.Genre
{
    public class GenreCommand : IGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<EntitiesEF.Genre, int> _rep;

        public GenreCommand(IMapper mapper, IBaseRepository<EntitiesEF.Genre, int> rep)
        {
            _mapper = mapper;
            _rep = rep;
        }

        public Responce<int> Create(GenreModel entity)
        {
            var dbReader = _mapper.Map<EntitiesEF.Genre>(entity);

            _rep.AddItem(dbReader);

            return new();
        }

        public Responce<int> Delete(int id)
        {
            _rep.DeleteById(id);

            return new()
            {
                Value = id
            };
        }

        public Responce<IEnumerable<GenreModel>> GetAll()
        {
            return new()
            {
                Value = _mapper.Map<IEnumerable<GenreModel>>(_rep.GetAll()),
            };
        }

        public Responce<GenreModel> GetById(int id)
        {
            var dbReader = _rep.GetById(id);

            var map = _mapper.Map<GenreModel>(dbReader);

            return new()
            {
                Value = map,
            };
        }

        public Responce<int> Update(int id, GenreModel entity)
        {
            entity.GenreId = id;

            var dbReader = _mapper.Map<EntitiesEF.Genre>(entity);

            _rep.UpdateItem(dbReader);

            return new()
            {
                Value = dbReader.GenreId
            };
        }
    }
}
