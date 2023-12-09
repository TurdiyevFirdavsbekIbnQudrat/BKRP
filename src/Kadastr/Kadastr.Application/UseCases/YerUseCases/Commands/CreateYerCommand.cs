using Kadastr.Domain.Entities;
using MediatR;

namespace Kadastr.Application.UseCases.YerUseCases.Commands
{
    public class CreateYerCommand : IRequest<Yer>
    {
        public int sotix { get; set; }
    }
}
