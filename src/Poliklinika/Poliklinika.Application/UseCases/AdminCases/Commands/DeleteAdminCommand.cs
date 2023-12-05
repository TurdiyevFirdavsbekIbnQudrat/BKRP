using MediatR;

namespace Poliklinika.Application.UseCases.AdminCases.Commands
{
    public class DeleteAdminCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
