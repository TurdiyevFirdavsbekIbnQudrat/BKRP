using Bogcha.API.DTOs;
using Bogcha.Application.UseCases.TokenCases.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bogcha.API.Controllers
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
        public async ValueTask<IActionResult> CreateAuthAsync(AuthDto model)
        {
            CreateBogchaAdminTokenCommand command = new CreateBogchaAdminTokenCommand()
            {
                Parol=model.Parol,
                UserName = model.UserName,
            };
            
            var result = await mediator.Send(command);
            return Ok(result);

        }
    
    }
}
