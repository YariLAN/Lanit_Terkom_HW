using EntitiesEF;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book, Guid> _rep;

        public BooksController(IBaseRepository<Book, Guid> rep)
        {
            _rep = rep;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _rep.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book? Get(Guid id)
        {
            return _rep.GetById(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book entity)
        {
            entity.BookId = Guid.NewGuid();

            _rep.AddItem(entity);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Book entity)
        {
            entity.BookId = id;

            _rep.UpdateItem(entity);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _rep.DeleteById(id);
        }
    }
}
