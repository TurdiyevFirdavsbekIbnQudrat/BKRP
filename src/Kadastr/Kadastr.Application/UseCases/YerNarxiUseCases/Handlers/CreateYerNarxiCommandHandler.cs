using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.YerNarxiUseCases.Commands;
using Kadastr.Domain.Entities;
using MediatR;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Handlers
{
    public class CreateYerNarxiCommandHandler : IRequestHandler<CreateYerNarxiCommand, YerNarxi>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public CreateYerNarxiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<YerNarxi> Handle(CreateYerNarxiCommand request, CancellationToken cancellationToken)
        {


            try
            {
                var yer = new YerNarxi()
                {
                    Viloyat = request.Viloyat,
                    YerNarx = request.YerNarx,
                };
                await _kadastrDbContext.YerNarxlar.AddAsync(yer);
                await _kadastrDbContext.SaveChangesAsync(cancellationToken);
                return yer;
            }
            catch
            {
                return new YerNarxi();
            }

        }

    }
}


