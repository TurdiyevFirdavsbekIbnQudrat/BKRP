using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.IshchilarCases.Queries;
using Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Queries;
using Poliklinika.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Handler
{
    public class GetByIdShifokorIshKunlariCommandHandler:IRequestHandler<GetByIdShifokorIshKunlariCommand,ShifokorIshKunlari>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public GetByIdShifokorIshKunlariCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public  async Task<ShifokorIshKunlari> Handle(GetByIdShifokorIshKunlariCommand request, CancellationToken cancellationToken)
        {

            try
            {
                ShifokorIshKunlari Ishchi =await poliknikaDbContext.shifokorningIshKunlari.FirstOrDefaultAsync(x=>x.Id==request.Id);
                return Ishchi;

            }
            catch
            {

                return new ShifokorIshKunlari();
            }
        }

    }
}
