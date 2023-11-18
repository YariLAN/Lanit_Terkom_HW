using EntitiesEF;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly IBaseRepository<Reader, Guid> _rep;

        public ReadersController(IBaseRepository<Reader, Guid> rep)
        {
            _rep = rep;
        }

        // GET: api/<ReaderController>
        [HttpGet]
        public IEnumerable<Reader> Get()
        {
            return _rep.GetAll();
        }

        // GET api/<ReaderController>/5
        [HttpGet("{id}")]
        public Reader? Get(Guid id)
        {
            return _rep.GetById(id);
        }

        // POST api/<ReaderController>
        [HttpPost]
        public void Post([FromBody] Reader entity)
        {
            entity.ReaderId = Guid.NewGuid();

            _rep.AddItem(entity);
        }

        // PUT api/<ReaderController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Reader entity)
        {
            entity.ReaderId = id;

            _rep.UpdateItem(entity);
        }

        // DELETE api/<ReaderController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _rep.DeleteById(id);
        }
    }
}
