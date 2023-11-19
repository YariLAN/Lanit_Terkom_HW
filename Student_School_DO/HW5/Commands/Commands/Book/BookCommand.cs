﻿using AutoMapper;
using FluentValidation.Results;
using Models;
using Repositories;
using Validation.Book.Interfaces;

namespace Commands.Commands.Book
{
    public class BookCommand : IBookCommand
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<EntitiesEF.Book, Guid> _rep;
        private readonly ICreateBookModelValidator _validator;

        public BookCommand(
            IMapper mapper,
            IBaseRepository<EntitiesEF.Book, Guid> rep,
            ICreateBookModelValidator validator)
        {
            _mapper = mapper;
            _rep = rep;
            _validator = validator;
        }

        public Responce<Guid> Create(BookModel entity)
        {
            ValidationResult validation = _validator.Validate(entity);
            if (!validation.IsValid)
            {
                return new()
                {
                    Errors = validation.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

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
            ValidationResult validation = _validator.Validate(entity);
            if (!validation.IsValid)
            {
                return new()
                {
                    Value = id,
                    Errors = validation.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

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
