using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.GuruhUseCases.Queries;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.GuruhUseCases.Handler
{
    public class GetAllGuruhCommandHandler : IRequestHandler<GetAllGuruhCommand, IEnumerable<Guruh>>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public GetAllGuruhCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<IEnumerable<Guruh>> Handle(GetAllGuruhCommand request, CancellationToken cancellationToken)
        {
            var HammaGuruh = await bogchaDbContext.Guruhlar.ToListAsync();
            if (HammaGuruh != null)
            {
                return HammaGuruh;
            }
            return Enumerable.Empty<Guruh>();
        }
    }
}
