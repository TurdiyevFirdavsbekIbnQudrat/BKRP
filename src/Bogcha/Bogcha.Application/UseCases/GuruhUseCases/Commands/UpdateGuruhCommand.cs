using MediatR;

namespace Bogcha.Application.UseCases.GuruhUseCases.Commands
{
    public class UpdateGuruhCommand:IRequest<string>
    {
        public int Id { get; set; }
        public string GuruhName { get; set; }
    }
}
