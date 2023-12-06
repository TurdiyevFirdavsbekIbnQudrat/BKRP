using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.DavomatUseCases.Queries
{
    public class GetByIdDavomatCommand : IRequest<Davomat>
    {
        public int Id { get; set; }
    }
}
