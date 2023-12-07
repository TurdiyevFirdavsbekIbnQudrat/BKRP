using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Commands.DeleteCommand;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Handlers
{
    public class DeleteFoydalanuvchiCommandHandler : IRequestHandler<DeleteFoydalanuvchiCommand, string>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public DeleteFoydalanuvchiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<string> Handle(DeleteFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {
            var BirFoydalanuvchi = await _kadastrDbContext.Foydalanuvchilar.FirstOrDefaultAsync();
            if (BirFoydalanuvchi != null)
            {
                try
                {
                    _kadastrDbContext.Foydalanuvchilar.Remove(BirFoydalanuvchi);
                    await _kadastrDbContext.SaveChangesAsync(cancellationToken);
                    return "O'chirildi!!!";
                }
                catch
                {
                    return "O'chirilmadi!!!";
                }

            }
            return "Ma'lumot mavjud emas!!!";

        }        
    }
}
