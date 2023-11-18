using Commands.Commands.Book;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookCommand _bookCommand;

        public BooksController(IBookCommand book)
        {
            _bookCommand = book;
        }

        // GET: api/<ReaderController>
        [HttpGet]
        public Responce<IEnumerable<BookModel>> Get()
        {
            return _bookCommand.GetAll();
        }

        // GET api/<ReaderController>/5
        [HttpGet("{id}")]
        public Responce<BookModel> Get(Guid id)
        {
            return _bookCommand.GetById(id);
        }

        // POST api/<ReaderController>
        [HttpPost]
        public Responce<Guid> Post([FromBody] BookModel entity)
        {
            return _bookCommand.Create(entity);
        }

        // PUT api/<ReaderController>/5
        [HttpPut("{id}")]
        public Responce<Guid> Put(Guid id, [FromBody] BookModel entity)
        {
            return _bookCommand.Update(id, entity);
        }

        // DELETE api/<ReaderController>/5
        [HttpDelete("{id}")]
        public Responce<Guid> Delete(Guid id)
        {
            return _bookCommand.Delete(id);
        }
    }
}
