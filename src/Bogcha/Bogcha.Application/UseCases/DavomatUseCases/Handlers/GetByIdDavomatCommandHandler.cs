using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.DavomatUseCases.Queries;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.DavomatUseCases.Handlers
{
    public class GetByIdDavomatCommandHandler : IRequestHandler<GetByIdDavomatCommand, Davomat>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public GetByIdDavomatCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<Davomat> Handle(GetByIdDavomatCommand request, CancellationToken cancellationToken)
        {
            var BirDavomat = await bogchaDbContext.Davomatlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirDavomat != null)
            {
                return BirDavomat;
            }
            return new Davomat();
        }
    }
}
