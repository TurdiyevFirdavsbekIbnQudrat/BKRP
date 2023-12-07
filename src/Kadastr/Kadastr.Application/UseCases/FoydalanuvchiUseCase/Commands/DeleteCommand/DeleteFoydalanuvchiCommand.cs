using MediatR;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Commands.DeleteCommand
{
    public class DeleteFoydalanuvchiCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
