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
            var BirBola = await bogchaDbContext.Bolalar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirBola != null)
            {
                try
                {
                    BirBola.Familiya = request.Familiya;
                    BirBola.Ism = request.Ism;
                 
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
