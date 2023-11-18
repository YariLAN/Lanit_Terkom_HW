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
        public Responce<IEnumerable<CategoryModel>> Get()
        {
            return _catCommand.GetAll();
        }

        // GET api/<GenreController>/<id>
        [HttpGet("{id}")]
        public Responce<CategoryModel> Get(int id)
        {
            return _catCommand.GetById(id);
        }

        // POST api/<GenreController>
        [HttpPost]
        public Responce<int> Post([FromBody] CategoryModel genre)
        {
            return _catCommand.Create(genre);
        }

        // PUT api/<GenreController>/<id>
        [HttpPut("{id}")]
        public Responce<int> Put([FromRoute] int id, [FromBody] CategoryModel genre)
        {
            return _catCommand.Update(id, genre);
        }

        // DELETE api/<GenreController>/<id>
        [HttpDelete("{id}")]
        public Responce<int> Delete(int id)
        {
            return _catCommand.Delete(id);
        }
    }
}
