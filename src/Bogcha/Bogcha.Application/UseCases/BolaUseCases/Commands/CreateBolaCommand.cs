using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.BolaUseCases.Commands
{
    public class CreateBolaCommand : IRequest<Bola>

    {
        public string Ism { get; set; }
        public string Familiya { get; set; }
        public string GuruhId { get; set; }
    }
}
