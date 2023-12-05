using MediatR;

namespace Poliklinika.Application.UseCases.AdminCases.Commands
{
    public class UpdateAdminCommand:IRequest<string>
    {
        public int Id {  get; set; }
        public string Parol { get; set; }
        public string UserName { get; set; }

    }
}
