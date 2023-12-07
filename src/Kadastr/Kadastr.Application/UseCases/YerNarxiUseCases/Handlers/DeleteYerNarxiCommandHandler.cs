using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.YerNarxiUseCases.Commands;
using Kadastr.Application.UseCases.YerUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Handlers
{
    public class DeleteYerNarxiCommandHandler:IRequestHandler<DeleteYerNarxiCommand,string>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public DeleteYerNarxiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }
        public async Task<string> Handle(DeleteYerNarxiCommand request, CancellationToken cancellationToken)
        {
            var yer = await _kadastrDbContext.YerNarxlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (yer != null)
            {
                try
                {
                    _kadastrDbContext.YerNarxlar.Remove(yer);
                    await _kadastrDbContext.SaveChangesAsync(cancellationToken);
                    return "O'chirildi!!";
                }
                catch
                {
                    return "O'chirilmadi!!";
                }
            }
            return "Ma'lumot topilmadi";
        }
    }
}
