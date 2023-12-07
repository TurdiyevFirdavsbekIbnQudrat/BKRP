using Bogcha.Application.Abstraction;
using Bogcha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.UseCases.TokenCases.Commands
{
    public class AdminlarMalumotlar:IRequestHandler<AdminMalumotlar1,IEnumerable<Admin>>
    {
        private readonly IBogchaDbContext _context; 
        public AdminlarMalumotlar(IBogchaDbContext context)
        {
            _context = context;
        }
        

        public async Task<IEnumerable<Admin>> Handle(AdminMalumotlar1 request, CancellationToken cancellationToken)
        {
            
            IEnumerable<Admin> s = await _context.Adminlar.ToListAsync();
            return s;
            
        }
    }
}
