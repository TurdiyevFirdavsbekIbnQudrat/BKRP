using Bogcha.Application.UseCases.TarbiyachiUseCases.Commands;
using Bogcha.Application.UseCases.TarbiyachiUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bogcha.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TarbiyachiController : ControllerBase
    {
        private readonly IMediator mediator;

        public TarbiyachiController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateTarbiyachiAsync(CreateTarbiyachiCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllTarbiyachiAsync()
        {
            return Ok(await mediator.Send(new GetAllTarbiyachiCommand()));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetTarbiyachiByIdAsync(int id)
        {
            GetByIdTarbiyachiCommand command = new GetByIdTarbiyachiCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteTarbiyachiById(int id)
        {
            DeleteTarbiyachiCommand command = new DeleteTarbiyachiCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateTarbiyachiById(UpdateTarbiyachiCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
