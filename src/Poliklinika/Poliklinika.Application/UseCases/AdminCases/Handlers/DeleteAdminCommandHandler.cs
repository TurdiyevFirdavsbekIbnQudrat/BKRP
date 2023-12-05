using MediatR;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.AdminCases.Commands;

namespace Poliklinika.Application.UseCases.AdminCases.Handlers
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, string>
    {
        private readonly IPoliklinikaDbContext poliklinikaDbContext;

        public DeleteAdminCommandHandler(IPoliklinikaDbContext _poliklinikaDbContext)
        {
            poliklinikaDbContext = _poliklinikaDbContext;
        }

        public async Task<string> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            var BirIshchi = await poliklinikaDbContext.Adminlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (BirIshchi != null)
            {
                try
                {
                     poliklinikaDbContext.Adminlar.Remove(BirIshchi);
                    await poliklinikaDbContext.SaveChangesAsync(cancellationToken);
                    return "o'chirildi!!!";
                }
                catch
                {
                    return "o'chirilmadi!!!";
                }
            }
            return "ma'lumot topilmadi!!!";
        }


    }
}
