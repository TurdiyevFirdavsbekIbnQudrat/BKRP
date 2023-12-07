using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.TarbiyachiUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Handler
{
    public class UpdateTarbiyachiCommandHandler : IRequestHandler<UpdateTarbiyachiCommand, string>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public UpdateTarbiyachiCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<string> Handle(UpdateTarbiyachiCommand request, CancellationToken cancellationToken)
        {
            var BirTarbiyachi = await bogchaDbContext.Tarbiyachilar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirTarbiyachi != null)
            {
                try
                {
                    BirTarbiyachi.Familiya = request.Familiya;
                    BirTarbiyachi.Ism = request.Ism;
                    BirTarbiyachi.GuruhId = request.GuruhId;

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
