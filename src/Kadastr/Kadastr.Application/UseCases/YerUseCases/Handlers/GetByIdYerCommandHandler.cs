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
    public class GetByIdYerCommandHandler:IRequestHandler<GetByIdYerCommand,Yer>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public GetByIdYerCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<Yer> Handle(GetByIdYerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var BirFoydalanuvchi = await _kadastrDbContext.Yerlar.FirstOrDefaultAsync();
                return BirFoydalanuvchi;
            }
            catch
            {
                return new Yer();
            }

        }
    }
}
