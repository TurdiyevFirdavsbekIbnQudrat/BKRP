using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.YerUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.YerUseCases.Handlers
{
    public class UpdateYerCommandHandler:IRequestHandler<UpdateYerCommand,string>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public UpdateYerCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }
        public async Task<string> Handle(UpdateYerCommand request, CancellationToken cancellationToken)
        {
            var yer = await _kadastrDbContext.Yerlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (yer != null)
            {
                try
                {
                    yer.FoydalanuvchiId = request.FoydalanuvchiId;
                    yer.sotix = request.sotix;
                    yer.YerNarxiId = request.YerNarxiId;
                    await _kadastrDbContext.SaveChangesAsync(cancellationToken);
                    return "Yangilanfi!!";
                }
                catch
                {
                    return "Yangilanmadi!!";
                }
            }
            return "Ma'lumot topilmadi";
        }
    }
}
