using EntitiesEF;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IBaseRepository<Genre, int> _rep;

        public GenreController(IBaseRepository<Genre, int> rep)
        {
            _rep = rep;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public List<Genre> Get()
        {
            var genre = _rep.GetAll();
            return genre;
        }

        // GET api/<GenreController>/<id>
        [HttpGet("{id}")]
        public Genre? Get(int id)
        {
            return _rep.GetById(id);
        }

        // POST api/<GenreController>
        [HttpPost]
        public void Post([FromBody] Genre genre)
        {
            _rep.AddItem(genre);
        }

        // PUT api/<GenreController>/<id>
        [HttpPut("{id}")]
        public void Put([FromRoute] int id, [FromBody] Genre genre)
        {
            genre.GenreId = id;

            _rep.UpdateItem(genre);
        }

        // DELETE api/<GenreController>/<id>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _rep.DeleteById(id);
        }
    }
}
