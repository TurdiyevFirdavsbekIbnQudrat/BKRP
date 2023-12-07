using MediatR;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Commands
{
    public class DeleteTarbiyachiCommand:IRequest<string>
    {
        public int Id { get; set; }
    }
}
