using MediatR;

namespace Bogcha.Application.UseCases.DavomatUseCases.Commands
{
    public class UpdateDavomatCommand : IRequest<string>
    {
        public int Id { get; set; }
        public int ishtirok { get; set; }
    }
}
