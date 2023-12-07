using Kadastr.API.DTOs.FoydalanuvchiDtos;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Commands.CreateCommand;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Commands.DeleteCommand;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Commands.UpdateCommand;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kadastr.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoydalanuvchiController : ControllerBase
    {
        private readonly IMediator mediator;

        public FoydalanuvchiController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        //      [Authorize]
        [HttpPost]
        public async ValueTask<IActionResult> CreateFoydalanuvchiAsync(CreateFoydalanuvchiCommand command)
        {
            var result = await mediator.Send(command);
            var createF = new CreateFoydalanuvchiDto()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Parol = result.Parol,
                UserName = result.UserName
            };
            return Ok(createF);
        }

        //    [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllFoydalanuvchiAsync()
        {
            return Ok(await mediator.Send(new GetAllFoydalanuvchiCommand()));
        }

        //  [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetFoydalanuvchiByIdAsync(int id)
        {
            var command = new GetByIdFoydalanuvchiCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteFoydalanuvchiById(int id)
        {
            DeleteFoydalanuvchiCommand command = new DeleteFoydalanuvchiCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateFoydalanuvchiById(UpdateFoydalanuvchiCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }

}
