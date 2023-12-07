using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.KunVaVaqtlarCases.Queries;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.KunVaVaqtlarCases.Handlers
{
    public class GetAllKunVaVaqtCommandHandler : IRequestHandler<GetAllKunVaVaqtCommand, IEnumerable<KunVaVaqt>>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public GetAllKunVaVaqtCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<IEnumerable<KunVaVaqt>> Handle(GetAllKunVaVaqtCommand request, CancellationToken cancellationToken)
        {

            try
            {
                IEnumerable<KunVaVaqt> HammaIshchilar = await poliknikaDbContext.kunVaqtlar.ToListAsync();
                return HammaIshchilar;

            }
            catch
            {

                return Enumerable.Empty<KunVaVaqt>();
            }
        }

    }
}
