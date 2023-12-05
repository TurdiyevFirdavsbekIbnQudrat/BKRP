using MediatR;

namespace Poliklinika.Application.UseCases.TokenCases.Commands
{
    public class CreateAdminTokenCommand : IRequest<string>
    {
        public string Parol { get; set; }
        public string UserName { get; set; }
    }
}
