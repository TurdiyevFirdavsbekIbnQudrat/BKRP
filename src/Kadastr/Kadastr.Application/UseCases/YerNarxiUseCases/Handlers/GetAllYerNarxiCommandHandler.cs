using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.YerNarxiUseCases.Queries;
using Kadastr.Application.UseCases.YerUseCases.Queries;
using Kadastr.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Handlers
{
    public class GetAllYerNarxiCommandHandler:IRequestHandler<GetAllYerNarxiCommand,IEnumerable<YerNarxi>>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public GetAllYerNarxiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<IEnumerable<YerNarxi>> Handle(GetAllYerNarxiCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var HammaFoydlanuvchilar = await _kadastrDbContext.YerNarxlar.ToListAsync();

                return HammaFoydlanuvchilar;
            }
            catch
            {
                return Enumerable.Empty<YerNarxi>();
            }
        }
    }
}
