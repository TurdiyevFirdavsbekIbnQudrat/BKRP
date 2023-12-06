using MediatR;

namespace Bogcha.Application.UseCases.GuruhUseCases.Commands
{
    public class DeleteGuruhCommand:IRequest<string>
    {
        public int Id { get; set; }
    }
}
