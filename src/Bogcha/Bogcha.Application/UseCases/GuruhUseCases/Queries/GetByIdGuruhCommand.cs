using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.GuruhUseCases.Queries
{
    public class GetByIdGuruhCommand : IRequest<Guruh>
    {
        public int Id { get; set; }
    }
}
