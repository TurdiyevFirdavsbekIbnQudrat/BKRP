using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.UseCases.AdminCases.Commands;
using Poliklinika.Application.UseCases.AdminCases.Queries;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;
using Poliklinika.Application.UseCases.IshchilarCases.Queries;

namespace Poliklinika.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAdminAsync(CreateAdminCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAdminAsync()
        {
            return Ok(await mediator.Send(new GetAllAdminCommand()));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAdminByIdAsync(int id)
        {
            var command = new GetByIdAdminCommand { id = id };
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAdminById(int id)
        {
            DeleteAdminCommand command = new DeleteAdminCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAdminById(UpdateAdminCommand command)
        {
            return Ok(await mediator.Send(command));
        }

    }
}
