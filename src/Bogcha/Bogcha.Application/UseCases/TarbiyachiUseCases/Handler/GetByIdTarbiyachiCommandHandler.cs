using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.GuruhUseCases.Queries;
using Bogcha.Application.UseCases.TarbiyachiUseCases.Queries;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Handler
{
    public class GetByIdTarbiyachiCommandHandler:IRequestHandler<GetByIdTarbiyachiCommand,Tarbiyachi>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public GetByIdTarbiyachiCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<Tarbiyachi> Handle(GetByIdTarbiyachiCommand request, CancellationToken cancellationToken)
        {
            var BirTarbiyachi = await bogchaDbContext.Tarbiyachilar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirTarbiyachi != null)
            {
                return BirTarbiyachi;
            }
            return new Tarbiyachi();
        }
    }
}
