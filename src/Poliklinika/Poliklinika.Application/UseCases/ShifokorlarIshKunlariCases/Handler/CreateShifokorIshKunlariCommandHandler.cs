using MediatR;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;
using Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Commands;
using Poliklinika.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Handler
{
    public class CreateShifokorIshKunlariCommandHandler : IRequestHandler<CreateShifokorIshKunlariCommand, ShifokorIshKunlari>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public CreateShifokorIshKunlariCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<ShifokorIshKunlari> Handle(CreateShifokorIshKunlariCommand request, CancellationToken cancellationToken)
        {
            var command = new ShifokorIshKunlari()
            {
                Dushanba = request.Dushanba,
                Seshanba = request.Seshanba,
                Chorshanba = request.Chorshanba,
                Payshanba = request.Payshanba,
                Juma = request.Juma,
                Shanba = request.Shanba,
                IshchId = request.IshchId,
            };
            try
            {
                await poliknikaDbContext.shifokorningIshKunlari.AddAsync(command);
                await poliknikaDbContext.SaveChangesAsync(cancellationToken);
                return command;

            }
            catch
            {
                return new ShifokorIshKunlari();
            }
        }
    }
}
