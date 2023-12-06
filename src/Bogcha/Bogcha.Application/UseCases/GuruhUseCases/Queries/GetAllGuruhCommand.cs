using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.GuruhUseCases.Queries
{
    public class GetAllGuruhCommand:IRequest<IEnumerable<Guruh>>
    {
        public int Id { get; set; }
        public string GuruhName { get; set; }

    }
}
