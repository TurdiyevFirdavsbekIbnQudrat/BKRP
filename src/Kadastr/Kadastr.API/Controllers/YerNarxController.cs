using Kadastr.API.DTOs.YerNarxDtos;
using Kadastr.Application.UseCases.YerNarxiUseCases.Commands;
using Kadastr.Application.UseCases.YerNarxiUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kadastr.API.Controllers
{
    [Route("api/yernarxlar")]
    [ApiController]
    public class YerNarxController : ControllerBase
    {
        private readonly IMediator mediator;

        public YerNarxController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        //      [Authorize]
        [HttpPost]
        public async ValueTask<IActionResult> CreateYerNarxAsync(CreateYerNarxiCommand command)
        {
            var result = await mediator.Send(command);
            var createY = new CreateYerNarxDto()
            {
                Id = result.Id,
                Viloyat = result.Viloyat,
                YerNarx = result.YerNarx,
            };
            return Ok(createY);
        }

        //    [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllYerNarxiAsync()
        {
            return Ok(await mediator.Send(new GetAllYerNarxiCommand()));
        }

        //  [Authorize]
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetByIdYerNarxiAsync(int id)
        {
            var command = new GetByIdYerNarxiCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteYerNarxiById(int id)
        {
            DeleteYerNarxiCommand command = new DeleteYerNarxiCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateYerNarxiById(UpdateYerNarxiCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
