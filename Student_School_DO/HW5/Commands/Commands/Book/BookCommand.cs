using AutoMapper;
using Models;
using Repositories;

namespace Commands.Commands.Book
{
    public class BookCommand : IBookCommand
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<EntitiesEF.Book, Guid> _rep;

        public BookCommand(IMapper mapper, IBaseRepository<EntitiesEF.Book, Guid> rep)
        {
            _mapper = mapper;
            _rep = rep;
        }

        public Responce<Guid> Create(BookModel entity)
        {
            // валидация

            // маппинг
            var dbReader = _mapper.Map<EntitiesEF.Book>(entity);

            dbReader.BookId = Guid.NewGuid();

            _rep.AddItem(dbReader);

            return new()
            {
                Value = dbReader.BookId,
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

        public Responce<IEnumerable<BookModel>> GetAll()
        {
            var dbReaders = _rep.GetAll();

            return new()
            {
                Value = _mapper.Map<IEnumerable<BookModel>>(dbReaders),
            };
        }

        public Responce<BookModel> GetById(Guid id)
        {
            var dbReader = _rep.GetById(id);

            var map = _mapper.Map<BookModel>(dbReader);

            return new()
            {
                Value = map
            };
        }

        public Responce<Guid> Update(Guid id, BookModel entity)
        {
            entity.BookId = id;

            var dbReader = _mapper.Map<EntitiesEF.Book>(entity);

            _rep.UpdateItem(dbReader);

            return new()
            {
                Value = dbReader.BookId,
            };
        }
    }
}
