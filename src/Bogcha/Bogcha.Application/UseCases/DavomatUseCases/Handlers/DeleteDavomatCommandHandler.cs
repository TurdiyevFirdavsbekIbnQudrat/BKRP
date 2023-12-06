using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.DavomatUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.DavomatUseCases.Handlers
{
    public class DeleteDavomatCommandHandler : IRequestHandler<DeleteDavomatCommand, string>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public DeleteDavomatCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<string> Handle(DeleteDavomatCommand request, CancellationToken cancellationToken)
        {
            var BirDavomat = await bogchaDbContext.Davomatlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirDavomat != null)
            {
                try
                {
                    bogchaDbContext.Davomatlar.Remove(BirDavomat);
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
