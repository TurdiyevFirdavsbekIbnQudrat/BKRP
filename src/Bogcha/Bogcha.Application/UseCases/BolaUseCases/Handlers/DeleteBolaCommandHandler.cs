using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.BolaUseCases.Commands;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.BolaUseCases.Handlers
{
    public class DeleteBolaCommandHandler:IRequestHandler<DeleteBolaCommand,string>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public DeleteBolaCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<string> Handle(DeleteBolaCommand request, CancellationToken cancellationToken)
        {
            var BirBola = await bogchaDbContext.Bolalar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirBola != null)
            {
                try
                {
                    bogchaDbContext.Bolalar.Remove(BirBola);
                    await bogchaDbContext.SaveChangesAsync(cancellationToken);
                    return "o'chirildi!!!";
                }
                catch
                {
                    return "o'chirilmadi!!!";
                }
            }
            return "ma'lumot topilmadi!!!";

        }
    }
}
