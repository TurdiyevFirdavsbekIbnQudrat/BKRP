using MediatR;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.IshchilarCases.Commands;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.IshchilarCases.Handlers
{
    public class CreateIshchiCommandHandler : IRequestHandler<CreateIshchilarCommand, Ishchi>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public CreateIshchiCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<Ishchi> Handle(CreateIshchilarCommand request, CancellationToken cancellationToken)
        {
            var command = new Ishchi()
            {
                Familiya = request.Familiya,
                Ism = request.Ism,
                Lavozimi = request.Lavozimi,
                XonaNomi = request.XonaNomi,
            };
            try
            {
               await poliknikaDbContext.Ishchilar.AddAsync(command);
               await poliknikaDbContext.SaveChangesAsync(cancellationToken);
               return command;
                
            }
            catch 
            {
                return new Ishchi();
            }
        }
    }
}
