using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.AdminCases.Commands;

namespace Poliklinika.Application.UseCases.AdminCases.Handlers
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, string>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public UpdateAdminCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<string> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var BirIshchi = await poliknikaDbContext.Adminlar.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (BirIshchi != null)
            {
                BirIshchi.Parol = request.Parol;
                BirIshchi.Username = request.UserName;
                try
                {

                    await poliknikaDbContext.SaveChangesAsync(cancellationToken);
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
