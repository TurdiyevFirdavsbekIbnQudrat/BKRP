using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.YerNarxiUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Handlers
{
    public class UpdateYerNarxiCommandHandler : IRequestHandler<UpdateYerNarxiCommand, string>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public UpdateYerNarxiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }
        public async Task<string> Handle(UpdateYerNarxiCommand request, CancellationToken cancellationToken)
        {
            var yer = await _kadastrDbContext.YerNarxlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (yer != null)
            {
                try
                {
                    yer.Viloyat = request.Viloyat;
                    yer.YerNarx = request.YerNarx;
                    await _kadastrDbContext.SaveChangesAsync(cancellationToken);
                    return "Yangilandi!!";
                }
                catch
                {
                    return "Yangilanmadi!!";
                }
            }
            return "Ma'lumot topilmadi";
        }
    }
}
