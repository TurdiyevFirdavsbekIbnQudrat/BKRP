using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.BolaUseCases.Queries;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.BolaUseCases.Handlers
{
    public class GetAllBolaCommandHandler : IRequestHandler<GetAllBolaCommand, IEnumerable<Bola>>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public GetAllBolaCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<IEnumerable<Bola>> Handle(GetAllBolaCommand request, CancellationToken cancellationToken)
        {
            var HammaBolalar = await bogchaDbContext.Bolalar.ToListAsync();
            if (HammaBolalar != null)
            {
                return HammaBolalar;
            }
            return Enumerable.Empty<Bola>();
        }
    }
}
