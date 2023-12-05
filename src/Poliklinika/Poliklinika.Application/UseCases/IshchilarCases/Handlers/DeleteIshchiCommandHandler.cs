using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Application.UseCases.IshchilarCases.Handlers
{
    public class DeleteIshchiCommandHandler : IRequestHandler<DeleteIshchiCommand, string>
    {
        private readonly IPoliklinikaDbContext poliklinikaDbContext;

        public DeleteIshchiCommandHandler(IPoliklinikaDbContext _poliklinikaDbContext)
        {
            poliklinikaDbContext = _poliklinikaDbContext;
        }

        public async Task<string> Handle(DeleteIshchiCommand request, CancellationToken cancellationToken)
        {
            var BirIshchi = await poliklinikaDbContext.Ishchilar.FirstOrDefaultAsync(x => x.Id == request.id);
            if (BirIshchi != null)
            {
                try
                {
                    poliklinikaDbContext.Ishchilar.Remove(BirIshchi);
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
