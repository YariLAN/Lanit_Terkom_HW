using Microsoft.AspNetCore.Mvc;

using Commands.Commands.Category;
using Models;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Interfaces;
using Models.Response.Category;
using Models.Request.Category;

namespace RabbitClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] ICreateMessagePublisher<CreateCategoryRequest, CreateCategoryResponse> msgPublisher,
            [FromBody] CategoryModel request)
        {
            var resp = msgPublisher.SendCreateMessage(new CreateCategoryRequest { Category = request });

            if (resp is null)
            {
                return BadRequest();
            }

            return Created("/category", resp);
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IGetAllMessagePublisher<GetAllBookResponse, BookModel> msgPublisher)
        {
            var resp = msgPublisher.SendGetAllMessage(new BookModel());

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp.Books);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromServices] IDeleteMessagePublisher<DeleteBookRequest, DeleteBookResponse> msgPublisher,
            [FromRoute] Guid id)
        {
            DeleteBookRequest request = new DeleteBookRequest { Id = id };

            var resp = msgPublisher.SendDeleteMessage(request);

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
        public IActionResult Update(
            [FromServices] IUpdateMessagePublisher<Guid, BookModel, UpdateBookResponse> msgPublisher,
            [FromRoute] Guid id,
            [FromBody] BookModel request)
        {
            var resp = msgPublisher.SendUpdateMessage(id, request);

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp);
        }
    }
}
