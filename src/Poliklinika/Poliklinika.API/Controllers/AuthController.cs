using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;
using Poliklinika.Application.UseCases.TokenCases.Commands;

namespace Poliklinika.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAuthAsync(CreateAdminTokenCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
