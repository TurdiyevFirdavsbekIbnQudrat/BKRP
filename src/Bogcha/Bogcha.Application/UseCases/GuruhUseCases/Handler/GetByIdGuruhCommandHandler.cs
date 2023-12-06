using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.GuruhUseCases.Queries;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.GuruhUseCases.Handler
{
    public class GetByIdGuruhCommandHandler : IRequestHandler<GetByIdGuruhCommand, Guruh>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public GetByIdGuruhCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<Guruh> Handle(GetByIdGuruhCommand request, CancellationToken cancellationToken)
        {
            var BirGuruh = await bogchaDbContext.Guruhlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirGuruh != null)
            {
                return BirGuruh;
            }
            return new Guruh();
        }
    }
}
