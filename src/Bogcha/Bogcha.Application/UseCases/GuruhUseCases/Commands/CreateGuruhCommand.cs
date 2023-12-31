﻿using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.GuruhUseCases.Commands
{
    public class CreateGuruhCommand : IRequest<Guruh>
    {
        public string GuruhName { get; set; }
    }
}
