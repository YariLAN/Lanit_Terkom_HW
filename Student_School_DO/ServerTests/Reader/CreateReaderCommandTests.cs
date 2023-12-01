using AutoMapper;
using Commands.Commands.Reader;
using FluentValidation.Results;
using Models;
using Moq;
using Repositories;
using Validation.Reader.Interfaces;

namespace ServerTests.Reader
{
    public class Tests
    {
        private Mock<ICreateReaderModelValidator> _createReaderModelValidator;
        private Mock<IMapper> _mapper;
        private Mock<IBaseRepository<EntitiesEF.Reader, Guid>> _rep;

        private ReaderCommand _command { get; set; }
        private EntitiesEF.Reader reader { get; set; }

        public EntitiesEF.Reader CreateReader()
        {
            return new EntitiesEF.Reader
            {
                ReaderId = Guid.NewGuid(),
                LastName = "Matveev",
                FirstName = "Yarik",
                Patronymic = "Alexevich",
                CategoryId = 1,
                Adress = "Spb",
                Email = "@q.solution.ru"
            };
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _createReaderModelValidator = new Mock<ICreateReaderModelValidator>();
            _mapper = new Mock<IMapper>();
            _rep = new Mock<IBaseRepository<EntitiesEF.Reader, Guid>>();

            _createReaderModelValidator
                .Setup(x => x.Validate(It.IsAny<ReaderModel>()))
                .Returns(new ValidationResult() { Errors = new List<ValidationFailure>() });

            _createReaderModelValidator
                .Setup(x => x.Validate(new ReaderModel() { FirstName = null}))
                .Returns(new ValidationResult()
                {
                    Errors = new List<ValidationFailure>
                    {
                        new ValidationFailure {ErrorMessage = "First name is empty"},
                    }
                });

            _mapper.Setup(x => x.Map<EntitiesEF.Reader>(new ReaderModel() { FirstName = "as"}))
                   .Returns(new EntitiesEF.Reader());

            _rep.Setup(x => x.AddItem(It.IsAny<EntitiesEF.Reader>()));

            _command = new ReaderCommand(_mapper.Object, _rep.Object, _createReaderModelValidator.Object);
        }

        [SetUp]
        public void Setup()
        {
            reader = new()
            {
                ReaderId = Guid.NewGuid()
            };
        }

        [Test]
        [TestCase("Yarik", "Mat", "Gen", 1, "Adress", "email")]
        public void CreateUserCommandReturnGuid(
            string LastName,
            string FirstName,
            string Patronymic,
            int CategoryId,
            string Adress,
            string email)
        {

            // act
            var actual = _command.Create(new ReaderModel()
            {
                ReaderId = Guid.NewGuid(),
                LastName = LastName,
                FirstName = FirstName,
                Patronymic = Patronymic,
                CategoryId = CategoryId,
                Adress = Adress,
                Email = email
            });

            Assert.AreEqual(reader.ReaderId, actual.Value);
        }
    }
}