using Commands.Commands.Category;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryCommand _catCommand;

        public CategoryController(ICategoryCommand category)
        {
            _catCommand = category;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public Response<IEnumerable<CategoryInfo>> Get()
        {
            return _catCommand.GetAll();
        }

        // GET api/<GenreController>/<id>
        [HttpGet("{id}")]
        public Response<CategoryInfo> Get(int id)
        {
            return _catCommand.GetById(id);
        }

        // POST api/<GenreController>
        [HttpPost]
        public Response<int> Post([FromBody] CategoryInfo genre)
        {
            return _catCommand.Create(genre);
        }

        // PUT api/<GenreController>/<id>
        [HttpPut("{id}")]
        public Response<int> Put([FromRoute] int id, [FromBody] CategoryInfo genre)
        {
            return _catCommand.Update(id, genre);
        }

        // DELETE api/<GenreController>/<id>
        [HttpDelete("{id}")]
        public Response<int> Delete(int id)
        {
            return _catCommand.Delete(id);
        }
    }
}
