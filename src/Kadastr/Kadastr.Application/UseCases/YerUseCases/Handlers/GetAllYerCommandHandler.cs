using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.FoydalanuvchiUseCase.Queries;
using Kadastr.Application.UseCases.YerUseCases.Queries;
using Kadastr.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.YerUseCases.Handlers
{
    public class GetAllYerCommandHandler:IRequestHandler<GetAllYerCommand,IEnumerable<Yer>>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public GetAllYerCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<IEnumerable<Yer>> Handle(GetAllYerCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var HammaFoydlanuvchilar = await _kadastrDbContext.Yerlar.ToListAsync();

                return HammaFoydlanuvchilar;
            }
            catch
            {
                return Enumerable.Empty<Yer>();
            }
        }
    }
}
