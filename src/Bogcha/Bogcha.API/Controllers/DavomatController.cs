using Bogcha.Application.UseCases.DavomatUseCases.Commands;
using Bogcha.Application.UseCases.DavomatUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bogcha.API.Controllers
{
    [Route("api/davomatlar")]
    [ApiController]
    public class DavomatController : ControllerBase
    {

        private readonly IMediator mediator;

        public DavomatController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [Authorize(Roles = "Admin,Tarbiyachi")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateDavomatAsync(CreateDavomatCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin,Tarbiyachi")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllDavomatAsync()
        {
            return Ok(await mediator.Send(new GetAllDavomatCommand()));
        }

        [Authorize(Roles = "Admin,Tarbiyachi")]
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetDavomatByIdAsync(int id)
        {
            GetByIdDavomatCommand command = new GetByIdDavomatCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteDavomatById(int id)
        {
            DeleteDavomatCommand command = new DeleteDavomatCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateDavomatById(UpdateDavomatCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
