using MediatR;

namespace Bogcha.Application.UseCases.DavomatUseCases.Commands
{
    public class DeleteDavomatCommand:IRequest<string>
    {
        public int Id { get; set; }
    }
}
