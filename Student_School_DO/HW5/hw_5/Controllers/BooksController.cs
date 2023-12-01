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
        public Response<IEnumerable<BookInfo>> Get()
        {
            return _bookCommand.GetAll();
        }

        // GET api/<ReaderController>/5
        [HttpGet("{id}")]
        public Response<BookInfo> Get(Guid id)
        {
            return _bookCommand.GetById(id);
        }

        // POST api/<ReaderController>
        [HttpPost]
        public Response<Guid> Post([FromBody] BookInfo entity)
        {
            return _bookCommand.Create(entity);
        }

        // PUT api/<ReaderController>/5
        [HttpPut("{id}")]
        public Response<Guid> Put(Guid id, [FromBody] BookInfo entity)
        {
            return _bookCommand.Update(id, entity);
        }

        // DELETE api/<ReaderController>/5
        [HttpDelete("{id}")]
        public Response<Guid> Delete(Guid id)
        {
            return _bookCommand.Delete(id);
        }
    }
}
