using Kadastr.API.DTOs.FoydalanuvchiDtos;
using Kadastr.API.DTOs.YerDtos;
using Kadastr.Application.UseCases.YerUseCases.Commands;
using Kadastr.Application.UseCases.YerUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kadastr.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class YerController : ControllerBase
    {
        private readonly IMediator mediator;

        public YerController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        //      [Authorize]
        [HttpPost]
        public async ValueTask<IActionResult> CreateYerAsync(CreateYerCommand command)
        {
            var result = await mediator.Send(command);
            var createY = new CreateYerDto()
            {
                Id = result.Id,
                sotix=result.sotix,
                FoydalanuvchiId=result.FoydalanuvchiId,
                YerNarxiId=result.YerNarxiId,
            };
            return Ok(createY);
        }

        //    [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllYerAsync()
        {
            return Ok(await mediator.Send(new GetAllYerCommand()));
        }

        //  [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdYerAsync(int id)
        {
            var command = new GetByIdYerCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteYerById(int id)
        {
            DeleteYerCommand command = new DeleteYerCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateYerById(UpdateYerCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
