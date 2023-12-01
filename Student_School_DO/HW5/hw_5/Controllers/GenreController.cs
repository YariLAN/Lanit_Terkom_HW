using Commands.Commands.Genre;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreCommand _genreCommand;

        public GenreController(IGenreCommand genre)
        {
            _genreCommand = genre;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public Response<IEnumerable<GenreInfo>> Get()
        {
            return _genreCommand.GetAll();
        }

        // GET api/<GenreController>/<id>
        [HttpGet("{id}")]
        public ActionResult<Response<GenreInfo>> Get(int id)
        {
            return _genreCommand.GetById(id);
        }

        // POST api/<GenreController>
        [HttpPost]
        public ActionResult<Response<int>> Post([FromBody] GenreInfo genre)
        {
            return _genreCommand.Create(genre);
        }

        // PUT api/<GenreController>/<id>
        [HttpPut("{id}")]
        public Response<int> Put([FromRoute] int id, [FromBody] GenreInfo genre)
        {
            return _genreCommand.Update(id, genre);
        }

        // DELETE api/<GenreController>/<id>
        [HttpDelete("{id}")]
        public Response<int> Delete(int id)
        {
            return _genreCommand.Delete(id);
        }
    }
}
