using MediatR;

namespace Bogcha.Application.UseCases.TokenCases.Commands
{
    public class CreateBogchaAdminTokenCommand : IRequest<string>
    {

        public string Parol { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
