using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Queries;
using Kadastr.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Handlers
{
    public class GetByIdFoydalanuvchiCommandHandler : IRequestHandler<GetByIdFoydalanuvchiCommand, Foydalanuvchi>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public GetByIdFoydalanuvchiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<Foydalanuvchi> Handle(GetByIdFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {
            try {
                var BirFoydalanuvchi = await _kadastrDbContext.Foydalanuvchilar.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                return BirFoydalanuvchi;
            }
            catch
            {
                return new Foydalanuvchi();
            }
            
        }
    }
}
