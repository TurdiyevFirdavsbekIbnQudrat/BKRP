using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.YerUseCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Application.UseCases.YerUseCases.Handlers
{
    public class DeleteYerCommandHandler : IRequestHandler<DeleteYerCommand, string>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public DeleteYerCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }
        public async Task<string> Handle(DeleteYerCommand request, CancellationToken cancellationToken)
        {
            var yer = await _kadastrDbContext.Yerlar.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (yer != null)
            {
                try
                {
                    _kadastrDbContext.Yerlar.Remove(yer);
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
