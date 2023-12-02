using AutoMapper;
using Commands.Commands.Reader;
using Moq;
using Repositories;
using Validation.Reader.Interfaces;

namespace ServerTests.Reader
{
    public class DeleteReaderTests
    {
        private Mock<IMapper> _mapper;
        private Mock<IBaseRepository<EntitiesEF.Reader, Guid>> _rep;
        private Mock<ICreateReaderModelValidator> _validator;

        private ReaderCommand _readerCommand;

        private Guid _guid;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _guid = Guid.NewGuid();

            _mapper = new Mock<IMapper>();

            _rep = new Mock<IBaseRepository<EntitiesEF.Reader, Guid>>();

            _rep.Setup(x => x.DeleteById(_guid));

            _validator = new Mock<ICreateReaderModelValidator>();
        }

        [SetUp]
        public void Setup()
        {
            _readerCommand = new ReaderCommand(_mapper.Object, _rep.Object, _validator.Object);
        }


        [Test]
        public void DeleteReaderTestIsOk()
        {
            var response = _readerCommand.Delete(_guid);

            Assert.NotNull(response.Messages);

            Assert.AreEqual(1, response.Messages.Count);
        }
    }
}
