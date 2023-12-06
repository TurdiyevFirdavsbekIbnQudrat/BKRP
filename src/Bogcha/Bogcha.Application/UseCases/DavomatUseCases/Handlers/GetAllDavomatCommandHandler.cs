using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.BolaUseCases.Queries;
using Bogcha.Application.UseCases.DavomatUseCases.Queries;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.DavomatUseCases.Handlers
{
    public class GetAllDavomatCommandHandler:IRequestHandler<GetAllDavomatCommand,IEnumerable<Davomat>>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public GetAllDavomatCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<IEnumerable<Davomat>> Handle(GetAllDavomatCommand request, CancellationToken cancellationToken)
        {
            var HammaDavomat = await bogchaDbContext.Davomatlar.ToListAsync();
            if (HammaDavomat != null)
            {
                return HammaDavomat;
            }
            return Enumerable.Empty<Davomat>();
        }
    }
}
