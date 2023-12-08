using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;
using Poliklinika.Application.UseCases.IshchilarCases.Queries;
using Poliklinika.Domain.Entities;

namespace Poliklinika.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IshchiController : ControllerBase
    {
        private readonly IMediator mediator;

        public IshchiController(IMediator _mediator)
        {
            mediator = _mediator;
        }
       [Authorize]
        [HttpPost]
        public async ValueTask<IActionResult> CreateIshchiAsync(CreateIshchilarCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllIshchiAsync()
        {
            return Ok(await mediator.Send(new GetAllishchiCommand()));
        }

        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetIshchiByIdAsync(int id)
        {
            var command  = new GetIshchiByIdCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteIshchiById(int id)
        {
            DeleteIshchiCommand command = new DeleteIshchiCommand() { id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateIshchiById(UpdateIshchiCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
