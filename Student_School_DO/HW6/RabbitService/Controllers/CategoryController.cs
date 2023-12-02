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
            [FromServices] ICreateMessagePublisher<CreateCategoryRequest, Task<CreateCategoryResponse>> msgPublisher,
            [FromBody] CategoryInfo request)
        {
            var resp = await msgPublisher.SendCreateMessage(new CreateCategoryRequest { Category = request });

            if (resp is null)
            {
                return BadRequest();
            }

            return Created("/category", resp);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllMessagePublisher<Task<GetAllCategoryResponse>, CategoryInfo> msgPublisher)
        {
            var resp = await msgPublisher.SendGetAllMessage(new CategoryInfo());

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp.Categories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteMessagePublisher<int, Task<DeleteCategoryResponse>> msgPublisher,
            [FromRoute] int id)
        {
            var resp = await msgPublisher.SendDeleteMessage(id);

            if (resp is null)
            {
                return BadRequest();
            }

            return Created($"/categories/{resp.Id}", resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromServices] IGetByIdMessagePublisher<int, Task<GetByIdCategoryResponse>> msgPublisher,
            [FromRoute] int id)
        {
            var resp = await msgPublisher.SendGetByIdMessage(id);

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp.Category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateMessagePublisher<int, CategoryInfo, Task<UpdateCategoryResponse>> msgPublisher,
            [FromRoute] int id,
            [FromBody] CategoryInfo request)
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
