using AutoMapper;
using Models;
using Repositories;

namespace Commands.Commands.Reader
{
    public class ReaderCommand : IReaderCommand
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<EntitiesEF.Reader, Guid> _rep;

        public ReaderCommand(IMapper mapper, IBaseRepository<EntitiesEF.Reader, Guid> rep)
        {
            _mapper = mapper;
            _rep = rep;
        }

        public Responce<Guid> Create(ReaderModel entity)
        {
            // валидация

            // маппинг
            var dbReader = _mapper.Map<EntitiesEF.Reader>(entity);

            dbReader.ReaderId = Guid.NewGuid();

            _rep.AddItem(dbReader);

            return new()
            {
                Value = dbReader.ReaderId,
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

        public Responce<IEnumerable<ReaderModel>> GetAll()
        {
            var dbReaders = _rep.GetAll();

            return new()
            {
                Value = _mapper.Map<IEnumerable<ReaderModel>>(dbReaders),
            };
        }

        public Responce<ReaderModel> GetById(Guid id)
        {
            var dbReader = _rep.GetById(id);

            var map = _mapper.Map<ReaderModel>(dbReader);

            return new()
            {
                Value = map,
            };
        }

        public Responce<Guid> Update(Guid id, ReaderModel entity)
        {
            entity.ReaderId = id;

            var dbReader = _mapper.Map<EntitiesEF.Reader>(entity);

            _rep.UpdateItem(dbReader);

            return new()
            {
                Value = dbReader.ReaderId,
            };
        }
    }
}
