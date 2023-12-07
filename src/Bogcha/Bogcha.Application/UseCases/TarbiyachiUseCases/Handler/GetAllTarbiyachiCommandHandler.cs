using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.TarbiyachiUseCases.Queries;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Handler
{
    public class GetAllTarbiyachiCommandHandler : IRequestHandler<GetAllTarbiyachiCommand, IEnumerable<Tarbiyachi>>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public GetAllTarbiyachiCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<IEnumerable<Tarbiyachi>> Handle(GetAllTarbiyachiCommand request, CancellationToken cancellationToken)
        {
            var HammaTarbiyachi = await bogchaDbContext.Tarbiyachilar.ToListAsync();
            if (HammaTarbiyachi != null)
            {
                return HammaTarbiyachi;
            }
            return Enumerable.Empty<Tarbiyachi>();
        }
    }
}
