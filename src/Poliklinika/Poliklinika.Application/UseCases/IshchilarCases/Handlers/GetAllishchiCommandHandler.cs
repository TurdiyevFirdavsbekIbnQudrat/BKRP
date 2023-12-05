using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.IshchilarCases.Queries;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.IshchilarCases.Handlers
{
    public class GetAllishchiCommandHandler : IRequestHandler<GetAllishchiCommand, IEnumerable<Ishchi>>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public GetAllishchiCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<IEnumerable<Ishchi>> Handle(GetAllishchiCommand request, CancellationToken cancellationToken)
        {

            try
            {
                IEnumerable<Ishchi> HammaIshchilar = await poliknikaDbContext.Ishchilar.ToListAsync();
                return HammaIshchilar;

            }
            catch
            {

                return Enumerable.Empty<Ishchi>();
            }
        }


    }
}
