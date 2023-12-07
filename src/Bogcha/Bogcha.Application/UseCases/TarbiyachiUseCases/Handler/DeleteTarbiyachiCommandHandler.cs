using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.GuruhUseCases.Commands;
using Bogcha.Application.UseCases.TarbiyachiUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Handler
{
    public class DeleteTarbiyachiCommandHandler : IRequestHandler<DeleteTarbiyachiCommand, string>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public DeleteTarbiyachiCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<string> Handle(DeleteTarbiyachiCommand request, CancellationToken cancellationToken)
        {
            var BirTarbiyachi = await bogchaDbContext.Tarbiyachilar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirTarbiyachi != null)
            {
                try
                {
                    bogchaDbContext.Tarbiyachilar.Remove(BirTarbiyachi);
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
