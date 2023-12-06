using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.GuruhUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.GuruhUseCases.Handler
{
    public class DeleteGuruhCommandHandler : IRequestHandler<DeleteGuruhCommand, string>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public DeleteGuruhCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<string> Handle(DeleteGuruhCommand request, CancellationToken cancellationToken)
        {
            var BirGuruh = await bogchaDbContext.Guruhlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirGuruh != null)
            {
                try
                {
                    bogchaDbContext.Guruhlar.Remove(BirGuruh);
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
