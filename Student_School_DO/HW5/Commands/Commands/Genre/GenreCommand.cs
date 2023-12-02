using AutoMapper;
using FluentValidation.Results;

using Models;
using Repositories;
using Validation.Genre.Interfaces;

namespace Commands.Commands.Genre
{
    public class GenreCommand : IGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<EntitiesEF.Genre, int> _rep;
        private readonly ICreateGenreModelValidator _validate;

        public GenreCommand(
            IMapper mapper,
            IBaseRepository<EntitiesEF.Genre, int> rep,
            ICreateGenreModelValidator validate)
        {
            _mapper = mapper;
            _rep = rep;
            _validate = validate;
        }

        public Response<int> Create(GenreInfo entity)
        {
            ValidationResult validation = _validate.Validate(entity);
            if (!validation.IsValid)
            {
                return new()
                {
                    Messages = validation.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var dbReader = _mapper.Map<EntitiesEF.Genre>(entity);
            _rep.AddItem(dbReader);

            return new();
        }

        public Response<int> Delete(int id)
        {
            _rep.DeleteById(id);

            return new()
            {
                Value = id
            };
        }

        public Response<IEnumerable<GenreInfo>> GetAll()
        {
            return new()
            {
                Value = _mapper.Map<IEnumerable<GenreInfo>>(_rep.GetAll()),
            };
        }

        public Response<GenreInfo> GetById(int id)
        {
            var dbReader = _rep.GetById(id);

            var map = _mapper.Map<GenreInfo>(dbReader);

            return new()
            {
                Value = map,
            };
        }

        public Response<int> Update(int id, GenreInfo entity)
        {
            ValidationResult validation = _validate.Validate(entity);
            if (!validation.IsValid)
            {
                return new()
                {
                    Value = id,
                    Messages = validation.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

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
