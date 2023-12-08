using MediatR;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.KunVaVaqtlarCases.Commands;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.KunVaVaqtlarCases.Handlers
{
    public class CreateKunVaVaqtCommandHandler : IRequestHandler<CreateKunVaVaqtCommand, KunVaVaqt>
    {
        private readonly IPoliklinikaDbContext poliknikaDbContext;

        public CreateKunVaVaqtCommandHandler(IPoliklinikaDbContext _poliknikaDbContext)
        {
            poliknikaDbContext = _poliknikaDbContext;
        }

        public async Task<KunVaVaqt> Handle(CreateKunVaVaqtCommand request, CancellationToken cancellationToken)
        {
            var command = new KunVaVaqt()
            {
                Kun = DateTime.Today.ToString(),
                Vaqt = "8:00",
            };
            try
            {
                await poliknikaDbContext.kunVaqtlar.AddAsync(command);
                await poliknikaDbContext.SaveChangesAsync(cancellationToken);
                return command;

            }
            catch
            {
                return new KunVaVaqt();
            }
        }
    }
}

