using Microsoft.AspNetCore.Mvc;

using Models;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] ICreateMessagePublisher<CreateBookRequest, CreateBookResponse> msgPublisher,
            [FromBody] BookInfo request)
        {
            var resp = msgPublisher.SendCreateMessage(new CreateBookRequest { Book = request });

            if (resp is null)
            {
                return BadRequest();
            }

            return Created("/books", resp);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllMessagePublisher<Task<GetAllBookResponse>, BookInfo> msgPublisher)
        {
            var resp = await msgPublisher.SendGetAllMessage(new BookInfo());

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp.Books);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteMessagePublisher<Guid, Task<DeleteBookResponse>> msgPublisher,
            [FromRoute] Guid id)
        {
            var resp = await msgPublisher.SendDeleteMessage(id);

            if (resp is null)
            {
                return BadRequest();
            }

            return Created($"/books/{resp.Id}", resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromServices] IGetByIdMessagePublisher<Guid, Task<GetByIdBookResponse>> msgPublisher,
            [FromRoute] Guid id)
        {
            var resp = await msgPublisher.SendGetByIdMessage(id);

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp.Book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateMessagePublisher<Guid, BookInfo, Task<UpdateBookResponse>> msgPublisher,
            [FromRoute] Guid id,
            [FromBody] BookInfo request)
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
