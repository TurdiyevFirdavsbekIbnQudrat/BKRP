using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.YerNarxiUseCases.Queries;
using Kadastr.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Handlers
{
    public class GetByIdYerNarxiCommandHandler
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public GetByIdYerNarxiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<YerNarxi> Handle(GetByIdYerNarxiCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var HammaFoydlanuvchilar = await _kadastrDbContext.YerNarxlar.FirstOrDefaultAsync(x=>x.Id==request.Id);

                return HammaFoydlanuvchilar;
            }
            catch
            {
                return new YerNarxi();
            }
        }
    }
}
