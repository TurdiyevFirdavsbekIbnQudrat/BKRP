using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Commands.UpdateCommand;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Handlers
{
    public class UpdateFoydalanuvchiCommandHandler : IRequestHandler<UpdateFoydalanuvchiCommand, string>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public UpdateFoydalanuvchiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<string> Handle(UpdateFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {

            var BirFoydalanuvchi = await _kadastrDbContext.Foydalanuvchilar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirFoydalanuvchi != null) {
                try
                {
                    BirFoydalanuvchi.FirstName = request.FirstName;
                    BirFoydalanuvchi.LastName = request.LastName;
                    BirFoydalanuvchi.UserName = request.UserName;
                    BirFoydalanuvchi.Parol = request.Parol;
                   await _kadastrDbContext.SaveChangesAsync(cancellationToken);
                    return "Yangilandi!!!";
                }
                catch
                {
                    return "Yangilanmadi!!!";
                }
                 
            }
            return "Ma'lumot topilmadi!!!!";
        }
    }
}
