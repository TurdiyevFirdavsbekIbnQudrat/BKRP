using Bogcha.Application.UseCases.BolaUseCases.Commands;
using Bogcha.Application.UseCases.BolaUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bogcha.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BolaController : ControllerBase
    {
        private readonly IMediator mediator;

        public BolaController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateBolaAsync(CreateBolaCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllBolaAsync()
        {
            return Ok(await mediator.Send(new GetAllBolaCommand()));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetBolaByIdAsync(int id)
        {
            GetByIdBolaCommand command = new GetByIdBolaCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteBolaById(int id)
        {
            DeleteBolaCommand command = new DeleteBolaCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateBolaById(UpdateBolaCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
