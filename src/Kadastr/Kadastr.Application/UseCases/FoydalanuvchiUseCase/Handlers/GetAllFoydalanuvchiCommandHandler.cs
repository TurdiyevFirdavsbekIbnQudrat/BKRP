using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Queries;
using Kadastr.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Handlers
{
    public class GetAllFoydalanuvchiCommandHandler : IRequestHandler<GetAllFoydalanuvchiCommand, IEnumerable<Foydalanuvchi>>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public GetAllFoydalanuvchiCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<IEnumerable<Foydalanuvchi>> Handle(GetAllFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var HammaFoydlanuvchilar = await _kadastrDbContext.Foydalanuvchilar.ToListAsync();
         
                return HammaFoydlanuvchilar;
            }
            catch
            {
                return Enumerable.Empty<Foydalanuvchi>();
            }
        }
    }
}
