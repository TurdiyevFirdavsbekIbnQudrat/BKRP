using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Queries;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Handler
{
    public class GetAllShifokorIshKunlariCommandHandler : IRequestHandler<GetAllShifokorIshKunlariCommand, IEnumerable<ShifokorIshKunlari>>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public GetAllShifokorIshKunlariCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<IEnumerable<ShifokorIshKunlari>> Handle(GetAllShifokorIshKunlariCommand request, CancellationToken cancellationToken)
        {

            try
            {
                IEnumerable<ShifokorIshKunlari> HammaIshchilar = await poliknikaDbContext.shifokorningIshKunlari.Include(x=>x.kunVaVaqt).ToListAsync();
                return HammaIshchilar;

            }
            catch
            {

                return Enumerable.Empty<ShifokorIshKunlari>();
            }
        }

    }
}
