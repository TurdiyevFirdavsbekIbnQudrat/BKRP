using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.AdminCases.Queries;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.AdminCases.Handlers
{
    public class GetAllAdminCommandHandler:IRequestHandler<GetAllAdminCommand, IEnumerable<Admin>>
    {
        private readonly IPoliklinikaDbContext poliklinikaDbContext;

        public GetAllAdminCommandHandler(IPoliklinikaDbContext _poliklinikaDbContext)
        {
            poliklinikaDbContext = _poliklinikaDbContext;
        }
        public async Task<IEnumerable<Admin>> Handle(GetAllAdminCommand request, CancellationToken cancellationToken)
        {

            try
            {
                IEnumerable<Admin> HammaIshchilar = await poliklinikaDbContext.Adminlar.ToListAsync();
                return HammaIshchilar;

            }
            catch
            {

                return Enumerable.Empty<Admin>();
            }
        }


    }
}
