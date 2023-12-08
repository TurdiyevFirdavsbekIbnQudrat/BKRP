using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;
using Poliklinika.Application.UseCases.IshchilarCases.Queries;
using Poliklinika.Application.UseCases.KunVaVaqtlarCases.Commands;
using Poliklinika.Domain.Entities;

namespace Poliklinika.API.Controllers
{
    [Route("api/kunvavaqtlar")]
    [ApiController]
    public class KunVaVaqtController : ControllerBase
    {
        private readonly IMediator mediator;

        public KunVaVaqtController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        [Authorize]
        [HttpPost]
        public async ValueTask<IActionResult> CreateKunVaVaqtAsync()
        {
            
            var result = await mediator.Send(new CreateKunVaVaqtCommand());
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllKunVaVaqtAsync()
        {
            return Ok(await mediator.Send(new GetAllishchiCommand()));
        }
    }
}
