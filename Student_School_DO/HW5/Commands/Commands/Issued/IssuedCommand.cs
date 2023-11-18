using AutoMapper;
using Models;
using Repositories;

namespace Commands.Commands.Issued
{
    public class IssuedCommand : IIssuedCommand
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<EntitiesEF.Issued, Guid> _rep;

        public IssuedCommand(IMapper mapper, IBaseRepository<EntitiesEF.Issued, Guid> rep)
        {
            _mapper = mapper;
            _rep = rep;
        }

        public Responce<Guid> Create(IssuedModel entity)
        {
            // валидация

            // маппинг
            var dbReader = _mapper.Map<EntitiesEF.Issued>(entity);

            dbReader.IssuedId = Guid.NewGuid();

            _rep.AddItem(dbReader);

            return new()
            {
                Value = dbReader.IssuedId,
                Errors = new List<string>()
            };
        }

        public Responce<Guid> Delete(Guid id)
        {
            _rep.DeleteById(id);

            return new()
            {
                Value = id
            };
        }

        public Responce<IEnumerable<IssuedModel>> GetAll()
        {
            var dbReaders = _rep.GetAll();

            var map = _mapper.Map<IEnumerable<IssuedModel>>(dbReaders);

            return new()
            {
                Value = map,
            };
        }

        public Responce<IssuedModel> GetById(Guid id)
        {
            var dbReader = _rep.GetById(id);

            var map = _mapper.Map<IssuedModel>(dbReader);

            return new()
            {
                Value = map,
            };
        }

        public Responce<Guid> Update(Guid id, IssuedModel entity)
        {
            entity.IssuedId = id;

            var dbReader = _mapper.Map<EntitiesEF.Issued>(entity);

            _rep.UpdateItem(dbReader);

            return new()
            {
                Value = dbReader.IssuedId,
            };
        }
    }
}
