using Microsoft.AspNetCore.Mvc;

using Models;
using Models.Request.Book;
using RabbitClient.Publishers.Books;

namespace RabbitClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // POST api/<ReaderController>
        [HttpPost]
        public IActionResult Post(
            [FromServices] IBookPublisher msgPublisher,
            [FromBody] BookModel request)
        {
            var resp = msgPublisher.SendCreateMessage(request);

            if (resp == null)
            {
                return BadRequest();
            }

            return Created("/books", resp);
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IBookPublisher msgPublisher)
        {
            var resp = msgPublisher.SendGetAllMessage(new BookModel());

            if (resp == null)
            {
                return BadRequest();
            }

            return Created("/books", resp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromServices] IBookPublisher msgPublisher,
            [FromRoute] Guid id)
        {
            DeleteBookRequest request = new DeleteBookRequest { Id = id };

            var resp = msgPublisher.SendDeleteMessage(request);

            if (resp == null)
            {
                return BadRequest();
            }

            return Created($"/books/{resp.Id}", resp);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromServices] IBookPublisher msgPublisher, Guid id)
        {
            var resp = msgPublisher.SendGetByIdMessage(id);

            if (resp == null)
            {
                return BadRequest();
            }

            return Created($"/books/{resp.BookId}", resp);
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromServices] IBookPublisher msgPublisher,
            [FromRoute] Guid id,
            [FromBody] BookModel request)
        {
            var resp = msgPublisher.SendUpdateMessage(id, request);

            if (resp == null)
            {
                return BadRequest();
            }

            return Created($"/books/{resp.Id}", resp);
        }
    }
}
