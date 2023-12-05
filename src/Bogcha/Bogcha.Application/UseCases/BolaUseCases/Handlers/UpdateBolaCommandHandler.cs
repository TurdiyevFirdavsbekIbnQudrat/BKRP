using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.BolaUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.BolaUseCases.Handlers
{
    public class UpdateBolaCommandHandler : IRequestHandler<UpdateBolaCommand,string>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public UpdateBolaCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<string> Handle(UpdateBolaCommand request, CancellationToken cancellationToken)
        {
            var BirIshchi = await bogchaDbContext.Bolalar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirIshchi != null)
            {
                BirIshchi.Familiya = request.Familiya;
                BirIshchi.Ism = request.Ism;
                BirIshchi.GuruhId = request.GuruhId;
                try
                {
                    await bogchaDbContext.SaveChangesAsync(cancellationToken);
                    return "yangilandi!!!";
                }
                catch
                {
                    return "yangilanmadi!!!";
                }
            }
            return "ma'lumot topilmadi!!!";

        }
    }
}
