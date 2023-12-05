using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;

namespace Poliklinika.Application.UseCases.IshchilarCases.Handlers
{
    public class UpdateIshchiCommandHandler : IRequestHandler<UpdateIshchiCommand, string>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public UpdateIshchiCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<string> Handle(UpdateIshchiCommand request, CancellationToken cancellationToken)
        {
            var BirIshchi = await poliknikaDbContext.Ishchilar.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (BirIshchi != null)
            {
                BirIshchi.Familiya = request.Familiya;
                BirIshchi.Ism = request.Ism;
                BirIshchi.Lavozimi = request.Lavozimi;
                BirIshchi.XonaNomi = request.XonaNomi;
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
