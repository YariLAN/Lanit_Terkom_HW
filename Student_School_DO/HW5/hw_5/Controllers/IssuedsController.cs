using Commands.Commands.Issued;
using Commands.Commands.Reader;
using EntitiesEF;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace hw_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuedsController : ControllerBase
    {
        private readonly IIssuedCommand _issuedCommand;

        public IssuedsController(IIssuedCommand issued)
        {
            _issuedCommand = issued;
        }

        // GET: api/<ReaderController>
        [HttpGet]
        public Response<IEnumerable<IssuedInfo>> Get()
        {
            return _issuedCommand.GetAll();
        }

        // GET api/<ReaderController>/5
        [HttpGet("{id}")]
        public Response<IssuedInfo> Get(Guid id)
        {
            return _issuedCommand.GetById(id);
        }

        // POST api/<ReaderController>
        [HttpPost]
        public Response<Guid> Post([FromBody] IssuedInfo entity)
        {
            return _issuedCommand.Create(entity);
        }

        // PUT api/<ReaderController>/5
        [HttpPut("{id}")]
        public Response<Guid> Put(Guid id, [FromBody] IssuedInfo entity)
        {
            return _issuedCommand.Update(id, entity);
        }

        // DELETE api/<ReaderController>/5
        [HttpDelete("{id}")]
        public Response<Guid> Delete(Guid id)
        {
            return _issuedCommand.Delete(id);
        }
    }
}
