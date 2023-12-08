using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Commands;
using Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Queries;

namespace Poliklinika.API.Controllers
{
    [Route("api/shifokorishkunlar")]
    [ApiController]
    public class ShifokorIshKunlariController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShifokorIshKunlariController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateShifokorIshKunlariAsync(CreateShifokorIshKunlariCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllShifokorIshKunlariAsync()
        {
            return Ok(await mediator.Send(new GetAllShifokorIshKunlariCommand()));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetShifokorIshKunlariByIdAsync(int id)
        {
            var command = new GetByIdShifokorIshKunlariCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteShifokorIshKunlariById(int id)
        {
            DeleteShifokorIshKunlariCommand command = new DeleteShifokorIshKunlariCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateAdminById(UpdateShifokorIshKunlariCommand command)
        {
            return Ok(await mediator.Send(command));
        }

    }
}
