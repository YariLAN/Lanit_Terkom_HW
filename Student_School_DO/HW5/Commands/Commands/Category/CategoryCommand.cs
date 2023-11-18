using AutoMapper;
using Models;
using Repositories;

namespace Commands.Commands.Category
{
    public class CategoryCommand : ICategoryCommand
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<EntitiesEF.Category, int> _rep;

        public CategoryCommand(IMapper mapper, IBaseRepository<EntitiesEF.Category, int> rep)
        {
            _mapper = mapper;
            _rep = rep;
        }

        public Responce<int> Create(CategoryModel entity)
        {
            var dbReader = _mapper.Map<EntitiesEF.Category>(entity);

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

        public Responce<IEnumerable<CategoryModel>> GetAll()
        {
            return new()
            {
                Value = _mapper.Map<IEnumerable<CategoryModel>>(_rep.GetAll()),
            };
        }

        public Responce<CategoryModel> GetById(int id)
        {
            var dbReader = _rep.GetById(id);

            var map = _mapper.Map<CategoryModel>(dbReader);

            return new()
            {
                Value = map,
            };
        }

        public Responce<int> Update(int id, CategoryModel entity)
        {
            entity.CategoryId = id;

            var dbReader = _mapper.Map<EntitiesEF.Category>(entity);

            _rep.UpdateItem(dbReader);

            return new()
            {
                Value = dbReader.CategoryId
            };
        }
    }
}
