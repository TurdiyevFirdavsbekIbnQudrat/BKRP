using MediatR;

namespace Bogcha.Application.UseCases.BolaUseCases.Commands
{
    public class DeleteBolaCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
