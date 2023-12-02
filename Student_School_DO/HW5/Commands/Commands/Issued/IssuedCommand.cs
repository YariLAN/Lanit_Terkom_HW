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

        public Response<Guid> Create(IssuedInfo entity)
        {
            // валидация

            // маппинг
            var dbReader = _mapper.Map<EntitiesEF.Issued>(entity);

            dbReader.IssuedId = Guid.NewGuid();

            _rep.AddItem(dbReader);

            return new()
            {
                Value = dbReader.IssuedId,
                Messages = new List<string>()
            };
        }

        public Response<Guid> Delete(Guid id)
        {
            _rep.DeleteById(id);

            return new()
            {
                Value = id
            };
        }

        public Response<IEnumerable<IssuedInfo>> GetAll()
        {
            var dbReaders = _rep.GetAll();

            var map = _mapper.Map<IEnumerable<IssuedInfo>>(dbReaders);

            return new()
            {
                Value = map,
            };
        }

        public Response<IssuedInfo> GetById(Guid id)
        {
            var dbReader = _rep.GetById(id);

            var map = _mapper.Map<IssuedInfo>(dbReader);

            return new()
            {
                Value = map,
            };
        }

        public Response<Guid> Update(Guid id, IssuedInfo entity)
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
