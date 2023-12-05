using MediatR;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.IshchilarCases.Commands
{
    public class CreateIshchilarCommand:IRequest<Ishchi>
    {
        public string Ism { get; set; }
        public string Familiya { get; set; }
        public string Lavozimi { get; set; }
        public string XonaNomi { get; set; }
    }
}
