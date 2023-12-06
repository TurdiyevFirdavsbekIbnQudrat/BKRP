using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.DavomatUseCases.Commands;
using Bogcha.Application.UseCases.GuruhUseCases.Commands;
using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.GuruhUseCases.Handler
{
    public class CreateGuruhCommandHandler : IRequestHandler<CreateGuruhCommand,Guruh>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public CreateGuruhCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<Guruh> Handle(CreateGuruhCommand request, CancellationToken cancellationToken)
        {

            var command = new Guruh()
            {
                GuruhName = request.GuruhName,
            };
            try
            {
                await bogchaDbContext.Guruhlar.AddAsync(command);
                await bogchaDbContext.SaveChangesAsync(cancellationToken);
                return command;

            }
            catch
            {
                return new Guruh();
            }

        }

    }
}
