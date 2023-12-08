using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.DavomatUseCases.Commands;
using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.DavomatUseCases.Handlers
{
    public class CreateDavomatCommandHandler : IRequestHandler<CreateDavomatCommand, Davomat>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public CreateDavomatCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<Davomat> Handle(CreateDavomatCommand request, CancellationToken cancellationToken)
        {

            var command = new Davomat()
            {
                ishtirok = request.ishtirok,

            };
            try
            {
                await bogchaDbContext.Davomatlar.AddAsync(command);
                await bogchaDbContext.SaveChangesAsync(cancellationToken);
                return command;

            }
            catch
            {
                return new Davomat();
            }

        }
    }
}
