using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Commands.CreateCommand;
using Kadastr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Handlers
{
    public class CreateFoydalanuvchiCommandHandler : IRequestHandler<CreateFoydalanuvchiCommand, Foydalanuvchi>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public CreateFoydalanuvchiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<Foydalanuvchi> Handle(CreateFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var command = new Foydalanuvchi()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Parol=request.Parol,
                    UserName=request.UserName

                };
                var HammaFoydalanuvchilarUserNameniTekshir = _kadastrDbContext.Rollars.Where(x => x.UserName == request.UserName);
                if (HammaFoydalanuvchilarUserNameniTekshir == null)
                {

                    var rollar = new Rollar()
                    {
                        Role = "Foydalanuvchi",
                        Parol = request.Parol,
                        UserName = request.UserName,
                    };

                    _kadastrDbContext.Rollars.Add(rollar);
                    _kadastrDbContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    command.UserName = "Boshqa Variantni Sinab ko'ring ,bu username oldin qo'llanilgan";
                    return command;
                }
                await _kadastrDbContext.Foydalanuvchilar.AddAsync(command);
                await _kadastrDbContext.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch
            {
                return new Foydalanuvchi();
            }
        }
    }
}
