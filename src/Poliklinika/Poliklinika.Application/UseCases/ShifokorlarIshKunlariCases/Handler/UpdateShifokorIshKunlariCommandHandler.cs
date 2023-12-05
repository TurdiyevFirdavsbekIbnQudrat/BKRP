using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;
using Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Commands;

namespace Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Handler
{
    public class UpdateShifokorIshKunlariCommandHandler : IRequestHandler<UpdateShifokorIshKunlariCommand, string>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public UpdateShifokorIshKunlariCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<string> Handle(UpdateShifokorIshKunlariCommand request, CancellationToken cancellationToken)
        {
            var BirIshchi = await poliknikaDbContext.shifokorningIshKunlari.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (BirIshchi != null)
            {
                BirIshchi.Dushanba = request.Dushanba;
                BirIshchi.Seshanba = request.Seshanba;
                BirIshchi.Chorshanba = request.Chorshanba;
                BirIshchi.Payshanba = request.Payshanba;
                BirIshchi.Juma = request.Juma;
                BirIshchi.Shanba = request.Shanba;
                
                try
                {

                    await poliknikaDbContext.SaveChangesAsync(cancellationToken);
                    return "yangilandi!!!";

                }
                catch
                {
                    return "yangilanmadi!!!";
                }
            }
            return "ma'lumot topilmadi!!!";

        }
    }
}
