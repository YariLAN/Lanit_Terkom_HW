using AutoMapper;
using Commands.Commands.Reader;
using FluentValidation.Results;
using Models;
using Moq;
using Repositories;
using Validation.Reader.Interfaces;

namespace ServerTests.Reader
{
    public class CreateReaderTests
    {
        private Mock<IMapper> _mapper;
        private Mock<IBaseRepository<EntitiesEF.Reader, Guid>> _rep;
        private Mock<ICreateReaderModelValidator> _validator;

        private ReaderCommand _readerCommand;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var anc = new EntitiesEF.Reader()
            {
                LastName = It.IsAny<string>(),
            };

            _mapper = new Mock<IMapper>();

            _mapper.Setup(x => x.Map<EntitiesEF.Reader>(It.IsAny<ReaderInfo>()))
                   .Returns(anc);

            _rep = new Mock<IBaseRepository<EntitiesEF.Reader, Guid>>();

            _rep.Setup(x => x.AddItem(anc));

            _validator = new Mock<ICreateReaderModelValidator>();

            _validator
                .Setup(x => x.Validate(It.Is<ReaderInfo>(x => x.FirstName != null)))
                .Returns(new ValidationResult()
                {
                    Errors = new List<ValidationFailure>()
                });

            _validator
                .Setup(x => x.Validate(It.Is<ReaderInfo>(x => x.FirstName == null)))
                .Returns(new ValidationResult()
                {
                    Errors = new List<ValidationFailure>
                    {
                        new ValidationFailure()
                        {
                            ErrorMessage = "First is empty"
                        }
                    }
                });
        }

        [SetUp]
        public void SetUp()
        {
            _readerCommand = new ReaderCommand(_mapper.Object, _rep.Object, _validator.Object);
        }

        [Test]
        public void CreateReaderTestIsOk()
        {
            var ok = _readerCommand.Create(new ReaderInfo()
            {
                FirstName = "Yarik"
            });

            Assert.IsTrue(Guid.TryParse(ok.Value.ToString(), out Guid guidResult));
        }

        [Test]
        public void CreateReaderTestIsNotOkByEmptyFirstName()
        {
            var ok = _readerCommand.Create(new ReaderInfo()
            {
                FirstName = null
            });

            Assert.That(ok.Messages[0] == "First is empty");
        }
    }
}
