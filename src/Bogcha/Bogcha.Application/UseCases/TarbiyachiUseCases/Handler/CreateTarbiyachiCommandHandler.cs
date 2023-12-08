using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.TarbiyachiUseCases.Commands;
using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Handler
{
    public class CreateTarbiyachiCommandHandler : IRequestHandler<CreateTarbiyachiCommand, Tarbiyachi>
    {
        private readonly IBogchaDbContext bogchaDbContext;

        public CreateTarbiyachiCommandHandler(IBogchaDbContext _bogchaDbContext)
        {
            bogchaDbContext = _bogchaDbContext;
        }

        public async Task<Tarbiyachi> Handle(CreateTarbiyachiCommand request, CancellationToken cancellationToken)
        {

            var command = new Tarbiyachi()
            {
                GuruhId = request.GuruhId,
                Familiya = request.Familiya,
                Ism = request.Ism,
                role = Domain.Enums.Role.Tarbiyachi,
            };
            try
            {
                await bogchaDbContext.Tarbiyachilar.AddAsync(command);
                await bogchaDbContext.SaveChangesAsync(cancellationToken);
                return command;

            }
            catch
            {
                return new Tarbiyachi();
            }

        }

    }
}
