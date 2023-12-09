using Bogcha.Application.UseCases.BolaUseCases.Commands;
using Bogcha.Application.UseCases.BolaUseCases.Queries;
using Bogcha.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bogcha.API.Controllers
{
    [Route("api/bolalar")]
    [ApiController]
    public class BolaController : ControllerBase
    {
        private readonly IMediator mediator;

        public BolaController(IMediator _mediator)
        {
            mediator = _mediator;
        }
       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateBolaAsync(CreateBolaCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        //[Authorize(Roles = "Admin,Tarbiyachi")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllBolaAsync()
        {
            return Ok(await mediator.Send(new GetAllBolaCommand()));
        }

      //  [Authorize(Roles = "Admin,Tarbiyachi")]
        
        [HttpGet("{id}")]

        public async ValueTask<IActionResult> GetBolaByIdAsync(int id)
        {
            GetByIdBolaCommand command = new GetByIdBolaCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

     //   [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteBolaById(int id)
        {
            DeleteBolaCommand command = new DeleteBolaCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

    //    [Authorize(Roles = "Admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateBolaById(UpdateBolaCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
