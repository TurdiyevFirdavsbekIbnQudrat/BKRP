using Bogcha.Application.UseCases.GuruhUseCases.Commands;
using Bogcha.Application.UseCases.GuruhUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bogcha.API.Controllers
{
    [Route("api/guruhlar")]
    [ApiController]
    public class GuruhController : ControllerBase
    {
        private readonly IMediator mediator;

        public GuruhController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateGuruhAsync(CreateGuruhCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllGuruhAsync()
        {
            return Ok(await mediator.Send(new GetAllGuruhCommand()));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetGuruhByIdAsync(int id)
        {
            GetByIdGuruhCommand command = new GetByIdGuruhCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteGuruhById(int id)
        {
            DeleteGuruhCommand command = new DeleteGuruhCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateGuruhById(UpdateGuruhCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
