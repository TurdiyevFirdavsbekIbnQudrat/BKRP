using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.DavomatUseCases.Queries
{
    public class GetAllDavomatCommand:IRequest<IEnumerable<Davomat>>
    {
        public int Id { get; set; }
        public int ishtirok { get; set; }
    }
}
