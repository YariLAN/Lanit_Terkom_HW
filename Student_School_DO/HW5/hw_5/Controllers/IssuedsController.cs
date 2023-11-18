using EntitiesEF;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuedsController : ControllerBase
    {
        private readonly IBaseRepository<Issued, Guid> _rep;

        public IssuedsController(IBaseRepository<Issued, Guid> rep)
        {
            _rep = rep;
        }

        // GET: api/<IssuedsController>
        [HttpGet]
        public IEnumerable<Issued> Get()
        {
            return _rep.GetAll();
        }

        // GET api/<IssuedsController>/5
        [HttpGet("{id}")]
        public Issued? Get(Guid id)
        {
            return _rep.GetById(id);
        }

        // POST api/<IssuedsController>
        [HttpPost]
        public void Post([FromBody] Issued entity)
        {
            entity.IssuedId = Guid.NewGuid();

            _rep.AddItem(entity);
        }

        // PUT api/<IssuedsController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Issued entity)
        {
            entity.ReaderId = id;

            _rep.UpdateItem(entity);
        }

        // DELETE api/<IssuedsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _rep.DeleteById(id);
        }
    }
}
