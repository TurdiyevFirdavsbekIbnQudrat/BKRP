using MediatR;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.AdminCases.Commands;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.AdminCases.Handlers
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, Admin>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public CreateAdminCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<Admin> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var command = new Admin()
            {
                Parol = request.Parol,
                Username = request.UserName,
            };
            try
            {
                await poliknikaDbContext.Adminlar.AddAsync(command);
                await poliknikaDbContext.SaveChangesAsync(cancellationToken);
                return command;

            }
            catch
            {
                return new Admin();
            }
        }
    }
}
