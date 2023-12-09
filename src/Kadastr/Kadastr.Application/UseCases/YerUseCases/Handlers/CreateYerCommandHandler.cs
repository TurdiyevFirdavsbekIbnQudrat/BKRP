using Kadastr.Application.Abstraction;
using Kadastr.Application.UseCases.YerUseCases.Commands;
using Kadastr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.YerUseCases.Handlers
{
    public class CreateYerCommandHandler : IRequestHandler<CreateYerCommand, Yer>
    {
        private readonly IKadastrDbContext _kadastrDbContext;

        public CreateYerCommandHandler(IKadastrDbContext kadastrDbContext)
        {
            _kadastrDbContext = kadastrDbContext;
        }

        public async Task<Yer> Handle(CreateYerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                    var yer = new Yer() {
                    sotix = request.sotix,
                     };
                await _kadastrDbContext.Yerlar.AddAsync(yer);
                await _kadastrDbContext.SaveChangesAsync(cancellationToken);
                return yer;
            }
            catch
            {
                return new Yer();
            }
        }
    }
}
