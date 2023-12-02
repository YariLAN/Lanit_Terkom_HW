using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request.Reader;
using Models.Response.Reader;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        //POST api/<ReaderController>
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] ICreateMessagePublisher<CreateReaderRequest, Task<CreateReaderResponse>> msgPublisher,
            [FromBody] ReaderInfo request)
        {
            var resp = await msgPublisher.SendCreateMessage(new CreateReaderRequest { Reader = request });

            if (resp is null)
            {
                return BadRequest();
            }

            return Created("/readers", resp);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllMessagePublisher<Task<GetAllReaderResponse>, ReaderInfo> msgPublisher)
        {
            var resp = await msgPublisher.SendGetAllMessage(new ReaderInfo());

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp.Readers);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteMessagePublisher<Guid, Task<DeleteReaderResponse>> msgPublisher,
            [FromRoute] Guid id)
        {
            var resp = await msgPublisher.SendDeleteMessage(id);

            if (resp is null)
            {
                return BadRequest();
            }

            return Created($"/readers/{resp.Id}", resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromServices] IGetByIdMessagePublisher<Guid, Task<GetByIdReaderResponse>> msgPublisher,
            [FromRoute] Guid id)
        {
            var resp = await msgPublisher.SendGetByIdMessage(id);

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp.Reader);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateMessagePublisher<Guid, ReaderInfo, Task<UpdateReaderResponse>> msgPublisher,
            [FromRoute] Guid id,
            [FromBody] ReaderInfo request)
        {
            var resp = await msgPublisher.SendUpdateMessage(id, request);

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp);
        }
    }
}
