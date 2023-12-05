﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Commands;
using Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Queries;

namespace Poliklinika.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShifokorIshKunlariController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShifokorIshKunlariController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateShifokorIshKunlariAsync(CreateShifokorIshKunlariCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllShifokorIshKunlariAsync()
        {
            return Ok(await mediator.Send(new GetAllShifokorIshKunlariCommand()));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetShifokorIshKunlariByIdAsync(int id)
        {
            var command = new GetByIdShifokorIshKunlariCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteShifokorIshKunlariById(int id)
        {
            DeleteShifokorIshKunlariCommand command = new DeleteShifokorIshKunlariCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAdminById(UpdateShifokorIshKunlariCommand command)
        {
            return Ok(await mediator.Send(command));
        }

    }
}
