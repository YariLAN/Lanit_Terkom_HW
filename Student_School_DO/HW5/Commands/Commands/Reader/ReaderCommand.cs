﻿using AutoMapper;
using FluentValidation.Results;
using Models;
using Repositories;

using Validation.Reader.Interfaces;

namespace Commands.Commands.Reader
{
    public class ReaderCommand : IReaderCommand
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<EntitiesEF.Reader, Guid> _rep;
        private readonly ICreateReaderModelValidator _validate;

        public ReaderCommand
            (IMapper mapper,
            IBaseRepository<EntitiesEF.Reader,
            Guid> rep, ICreateReaderModelValidator validate)
        {
            _mapper = mapper;
            _rep = rep;
            _validate = validate;
        }

        public Response<Guid> Create(ReaderInfo entity)
        {
            ValidationResult validation = _validate.Validate(entity);
            if (!validation.IsValid)
            {
                return new()
                {
                    Errors = validation.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var dbReader = _mapper.Map<EntitiesEF.Reader>(entity);

            dbReader.ReaderId = Guid.NewGuid();

            _rep.AddItem(dbReader);

            return new()
            {
                Value = dbReader.ReaderId,
                Errors = new List<string>()
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

        public Response<IEnumerable<ReaderInfo>> GetAll()
        {
            var dbReaders = _rep.GetAll();

            return new()
            {
                Value = _mapper.Map<IEnumerable<ReaderInfo>>(dbReaders),
            };
        }

        public Response<ReaderInfo> GetById(Guid id)
        {
            var dbReader = _rep.GetById(id);

            var map = _mapper.Map<ReaderInfo>(dbReader);

            return new()
            {
                Value = map,
            };
        }

        public Response<Guid> Update(Guid id, ReaderInfo entity)
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
