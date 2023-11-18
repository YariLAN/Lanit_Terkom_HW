using EntitiesEF;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IBaseRepository<Category, int> _rep;

        public CategoryController(IBaseRepository<Category, int> rep)
        {
            _rep = rep;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public List<Category> Get()
        {
            return _rep.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category? Get(int id)
        {
            return _rep.GetById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category entity)
        {
            _rep.AddItem(entity);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category entity)
        {
            entity.CategoryId = id;

            _rep.UpdateItem(entity);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _rep.DeleteById(id);
        }
    }
}
