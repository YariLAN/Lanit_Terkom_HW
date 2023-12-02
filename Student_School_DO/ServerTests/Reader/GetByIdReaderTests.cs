using AutoMapper;
using Commands.Commands.Reader;
using Models;
using Moq;
using Repositories;
using Validation.Reader.Interfaces;

namespace ServerTests.Reader
{
    public class GetByIdReaderTests
    {
        private Mock<IMapper> _mapper;
        private Mock<IBaseRepository<EntitiesEF.Reader, Guid>> _rep;
        private Mock<ICreateReaderModelValidator> _validator;

        private ReaderCommand _readerCommand;

        private Guid _guid;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _rep = new Mock<IBaseRepository<EntitiesEF.Reader, Guid>>();

            _guid = Guid.NewGuid();

            EntitiesEF.Reader? reader = new EntitiesEF.Reader()
            {
                ReaderId = _guid,
                LastName = "Yarik",
                FirstName = "Matveev",
                Patronymic = "Ok",
                CategoryId = 1,
            };

            _rep.Setup(x => x.GetById(_guid))
                .Returns(reader);

            _mapper = new Mock<IMapper>();

            _mapper.Setup(x => x.Map<ReaderInfo>(reader))
                    .Returns(new ReaderInfo() { ReaderId = _guid });

            _validator = new Mock<ICreateReaderModelValidator>();
        }

        [SetUp]
        public void Setup()
        {
            _readerCommand = new ReaderCommand(_mapper.Object, _rep.Object, _validator.Object);
        }

        [Test]
        public void GetByIdReaderTestIsOk()
        {
            var reader = _readerCommand.GetById(_guid);

            Assert.AreEqual(reader.Value.ReaderId, _guid);
        }
    }
}
