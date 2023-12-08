using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.BolaUseCases.Queries
{
    public class GetAllBolaCommand:IRequest<IEnumerable<Bola>>
    {
        public int Id { get; set; }
        public string Ism { get; set; }
        public string Familiya { get; set; }
  

    }
}
