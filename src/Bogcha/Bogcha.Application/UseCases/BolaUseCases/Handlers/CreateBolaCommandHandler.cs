using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.BolaUseCases.Commands;
using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.BolaUseCases.Handlers
{
    public class CreateBolaCommandHandler : IRequestHandler<CreateBolaCommand, Bola>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public CreateBolaCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<Bola> Handle(CreateBolaCommand request, CancellationToken cancellationToken)
        {

            var command = new Bola()
            {
                Ism = request.Ism,
                Familiya = request.Familiya,
            
            };
            try
            {
                await bogchaDbContext.Bolalar.AddAsync(command);
                await bogchaDbContext.SaveChangesAsync(cancellationToken);
                return command;

            }
            catch
            {
                return new Bola();
            }

        }
    }
}
