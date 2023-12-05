using MediatR;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.IshchilarCases.Queries
{
    public class GetIshchiByIdCommand:IRequest<Ishchi>
    {
        public int Id { get; set; }
    }
}
