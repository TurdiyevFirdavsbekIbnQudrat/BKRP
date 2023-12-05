using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.BolaUseCases.Queries;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.BolaUseCases.Handlers
{
    public class GetByIdBolaCommandHandler:IRequestHandler<GetByIdBolaCommand,Bola>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public GetByIdBolaCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<Bola> Handle(GetByIdBolaCommand request, CancellationToken cancellationToken)
        {
            var HammaBolalar = await bogchaDbContext.Bolalar.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (HammaBolalar != null)
            {
                return HammaBolalar;
            }
            return new Bola();
        }
    }
}
