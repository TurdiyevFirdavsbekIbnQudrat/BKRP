using Kadastr.Domain.Entities;
using MediatR;

namespace Kadastr.Application.UseCases.YerUseCases.Commands
{
    public class CreateYerCommand : IRequest<Yer>
    {
        public int sotix { get; set; }
        public int YerNarxiId { get; set; }
        public int FoydalanuvchiId { get; set; }
    }
}
