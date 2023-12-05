using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;
using Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Handler
{
    public class DeleteShifokorIshKunlariCommandHandler:IRequestHandler<DeleteShifokorIshKunlariCommand,string>
    {
        private readonly IPoliklinikaDbContext poliklinikaDbContext;

        public DeleteShifokorIshKunlariCommandHandler(IPoliklinikaDbContext _poliklinikaDbContext)
        {
            poliklinikaDbContext = _poliklinikaDbContext;
        }

        public async Task<string> Handle(DeleteShifokorIshKunlariCommand request, CancellationToken cancellationToken)
        {
            var BirIshchi = await poliklinikaDbContext.shifokorningIshKunlari.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirIshchi != null)
            {
                try
                {
                    poliklinikaDbContext.shifokorningIshKunlari.Remove(BirIshchi);
                    await poliklinikaDbContext.SaveChangesAsync(cancellationToken);
                    return "o'chirildi!!!";
                }
                catch
                {
                    return "o'chirilmadi!!!";
                }
            }
            return "ma'lumot topilmadi!!!";
        }
    }
}
