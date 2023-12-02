using AutoMapper;
using Commands.Commands.Reader;
using FluentValidation.Results;
using Models;
using Moq;
using Repositories;
using Validation.Reader.Interfaces;

namespace ServerTests.Reader
{
    public class UpdateReaderTests
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

            var anc = new EntitiesEF.Reader()
            {
                ReaderId = _guid,
                LastName = It.IsAny<string>(),
            };

            _mapper = new Mock<IMapper>();

            _mapper.Setup(x => x.Map<EntitiesEF.Reader>(It.IsAny<ReaderModel>()))
                   .Returns(anc);

            _rep = new Mock<IBaseRepository<EntitiesEF.Reader, Guid>>();

            _rep.Setup(x => x.UpdateItem(anc));

            _validator = new Mock<ICreateReaderModelValidator>();

            _validator
                .Setup(x => x.Validate(It.IsAny<ReaderModel>()))
                .Returns(new ValidationResult()
                {
                    Errors = new List<ValidationFailure>()
                });
        }

        [SetUp]
        public void SetUp()
        {
            _readerCommand = new ReaderCommand(_mapper.Object, _rep.Object, _validator.Object);
        }

        [Test]
        public void UpdateReaderTestIsOk()
        {
            var ok = _readerCommand.Update(_guid, new ReaderModel()
            {
                LastName = "Matveev",
            });

            Assert.AreEqual(ok.Messages[0], "Is Update");
        }
    }
}
