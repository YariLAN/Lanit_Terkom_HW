using AutoMapper;
using Commands.Commands.Reader;
using FluentValidation.Results;
using Models;
using Moq;
using Repositories;
using Validation.Reader.Interfaces;

namespace ServerTests.Reader
{
    public class GetAllReaderTests
    {
        private Mock<IMapper> _mapper;
        private  Mock<IBaseRepository<EntitiesEF.Reader, Guid>> _rep;
        private Mock<ICreateReaderModelValidator> _validator;

        private ReaderCommand _readerCommand;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mapper = new Mock<IMapper>();

            _mapper.Setup(x => x.Map<IEnumerable<ReaderInfo>>(It.IsAny<IEnumerable<EntitiesEF.Reader>>()))
                   .Returns(GetReaderModels());

            _rep = new Mock<IBaseRepository<EntitiesEF.Reader, Guid>>();

            _rep.Setup(x => x.GetAll())
                .Returns(GetReaders());

            _validator = new Mock<ICreateReaderModelValidator>();

            _validator
                .Setup(x => x.Validate(null))
                .Returns(new ValidationResult() { });
        }

        [SetUp]
        public void Setup()
        {
            _readerCommand = new ReaderCommand(_mapper.Object, _rep.Object, _validator.Object);
        }

        [Test]
        public void GetAllReaderTestIsOk()
        {
            var actual = _readerCommand.GetAll();

            Assert.AreEqual(actual.Value.Count(), 5);
        }

        private List<EntitiesEF.Reader> GetReaders()
        {
            return new List<EntitiesEF.Reader>
            {
                new EntitiesEF.Reader(),
                new EntitiesEF.Reader(),
                new EntitiesEF.Reader(),
                new EntitiesEF.Reader(),
                new EntitiesEF.Reader()
            };
        }

        private List<ReaderInfo> GetReaderModels()
        {
            return new List<ReaderInfo>
            {
                new ReaderInfo(),
                new ReaderInfo(),
                new ReaderInfo(),
                new ReaderInfo(),
                new ReaderInfo()
            };
        }
    }
}