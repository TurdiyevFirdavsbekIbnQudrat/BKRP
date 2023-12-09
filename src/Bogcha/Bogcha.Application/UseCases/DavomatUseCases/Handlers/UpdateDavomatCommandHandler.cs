using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.DavomatUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.DavomatUseCases.Handlers
{
    public class UpdateDavomatCommandHandler : IRequestHandler<UpdateDavomatCommand, string>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public UpdateDavomatCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<string> Handle(UpdateDavomatCommand request, CancellationToken cancellationToken)
        {
            var BirDavomat = await bogchaDbContext.Davomatlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirDavomat != null)
            {
                try
                {
                    BirDavomat.ishtirok = request.ishtirok;
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
