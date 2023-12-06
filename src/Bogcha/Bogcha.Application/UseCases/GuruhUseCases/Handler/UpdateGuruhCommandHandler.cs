using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.DavomatUseCases.Commands;
using Bogcha.Application.UseCases.GuruhUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.GuruhUseCases.Handler
{
    public class UpdateGuruhCommandHandler : IRequestHandler<UpdateGuruhCommand, string>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public UpdateGuruhCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<string> Handle(UpdateGuruhCommand request, CancellationToken cancellationToken)
        {
            var BirGuruh = await bogchaDbContext.Guruhlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirGuruh != null)
            {
                try
                {
                    BirGuruh.GuruhName = request.GuruhName;
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
