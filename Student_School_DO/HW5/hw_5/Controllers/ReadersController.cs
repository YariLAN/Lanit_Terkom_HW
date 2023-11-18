using Commands.Commands.Reader;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly IReaderCommand _readerCommand;

        public ReadersController(IReaderCommand reader)
        {
            _readerCommand = reader;
        }

        // GET: api/<ReaderController>
        [HttpGet]
        public Responce<IEnumerable<ReaderModel>> Get()
        {
            return _readerCommand.GetAll();
        }

        // GET api/<ReaderController>/5
        [HttpGet("{id}")]
        public Responce<ReaderModel> Get(Guid id)
        {
            return _readerCommand.GetById(id);
        }

        // POST api/<ReaderController>
        [HttpPost]
        public Responce<Guid> Post([FromBody] ReaderModel entity)
        {
            return _readerCommand.Create(entity);
        }

        // PUT api/<ReaderController>/5
        [HttpPut("{id}")]
        public Responce<Guid> Put(Guid id, [FromBody] ReaderModel entity)
        {
            return _readerCommand.Update(id, entity);
        }

        // DELETE api/<ReaderController>/5
        [HttpDelete("{id}")]
        public Responce<Guid> Delete(Guid id)
        {
            return _readerCommand.Delete(id);
        }
    }
}
