using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.IshchilarCases.Queries;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.IshchilarCases.Handlers
{
    public class GetIshchiByIdCommandHandler : IRequestHandler<GetIshchiByIdCommand, Ishchi>
    {
        private readonly IPoliklinikaDbContext poliklinikaDbContext;

        public GetIshchiByIdCommandHandler(IPoliklinikaDbContext _poliklinikaDbContext)
        {
            poliklinikaDbContext = _poliklinikaDbContext;
        }

        public async Task<Ishchi> Handle(GetIshchiByIdCommand request, CancellationToken cancellationToken)
        {
            
            
                Ishchi BirIshchi = poliklinikaDbContext.Ishchilar.Include(x=>x.shifokorIshKunlari).Where(x=>x.Id==request.Id) as Ishchi;
            if (BirIshchi != null)
            {
                var command = new Ishchi()
                {   Id = BirIshchi.Id,
                    Familiya = BirIshchi.Familiya,
                    Ism = BirIshchi.Ism,
                    Lavozimi = BirIshchi.Lavozimi,
                    XonaNomi = BirIshchi.XonaNomi,
                    shifokorIshKunlari=BirIshchi.shifokorIshKunlari
                };
                return command;
            }
            else
            {
                return new Ishchi();
            }
            
        }
    }
}
