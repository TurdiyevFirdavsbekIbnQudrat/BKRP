using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.BolaUseCases.Queries
{
    public class GetByIdBolaCommand:IRequest<Bola>
    {
        public int Id { get; set; }
    }
}
