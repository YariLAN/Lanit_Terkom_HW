using AutoMapper;
using FluentValidation.Results;
using Models;
using Repositories;
using Validation.Category.Interfaces;

namespace Commands.Commands.Category
{
    public class CategoryCommand : ICategoryCommand
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<EntitiesEF.Category, int> _rep;
        private readonly ICreateCategoryModelValidator _validate;

        public CategoryCommand(
            IMapper mapper,
            IBaseRepository<EntitiesEF.Category, int> rep,
            ICreateCategoryModelValidator validate)
        {
            _mapper = mapper;
            _rep = rep;
            _validate = validate;
        }

        public Response<int> Create(CategoryInfo entity)
        {
            ValidationResult validation = _validate.Validate(entity);
            if (!validation.IsValid)
            {
                return new()
                {
                    Errors = validation.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var dbReader = _mapper.Map<EntitiesEF.Category>(entity);

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

        public Response<IEnumerable<CategoryInfo>> GetAll()
        {
            return new()
            {
                Value = _mapper.Map<IEnumerable<CategoryInfo>>(_rep.GetAll()),
            };
        }

        public Response<CategoryInfo> GetById(int id)
        {
            var dbReader = _rep.GetById(id);

            var map = _mapper.Map<CategoryInfo>(dbReader);

            return new()
            {
                Value = map,
            };
        }

        public Response<int> Update(int id, CategoryInfo entity)
        {
            ValidationResult validation = _validate.Validate(entity);
            if (!validation.IsValid)
            {
                return new()
                {
                    Value = id,
                    Errors = validation.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

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
