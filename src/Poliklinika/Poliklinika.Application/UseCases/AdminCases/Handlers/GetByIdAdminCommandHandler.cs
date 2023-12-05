using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.AdminCases.Queries;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.AdminCases.Handlers
{
    public class GetByIdAdminCommandHandler : IRequestHandler<GetByIdAdminCommand, Admin>
    {

        private readonly IPoliklinikaDbContext poliklinikaDbContext;

        public GetByIdAdminCommandHandler(IPoliklinikaDbContext _poliklinikaDbContext)
        {
            poliklinikaDbContext = _poliklinikaDbContext;
        }

        public async Task<Admin> Handle(GetByIdAdminCommand request, CancellationToken cancellationToken)
        {
            var BirIshchi = await poliklinikaDbContext.Adminlar.FirstOrDefaultAsync(x => x.Id == request.id);
            if (BirIshchi != null)
            {
                var command = new Admin()
                {
                    Id = BirIshchi.Id,
                    Parol = BirIshchi.Parol,
                    Username =BirIshchi.Username,
                };
                return command;
            }
            else
            {
                return new Admin();
            }

        }
    }
}
