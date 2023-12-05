using MediatR;

namespace Poliklinika.Application.UseCases.IshchilarCases.Commands
{
    public class UpdateIshchiCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Ism { get; set; }
        public string Familiya { get; set; }
        public string Lavozimi { get; set; }
        public string XonaNomi { get; set; }

    }
}
