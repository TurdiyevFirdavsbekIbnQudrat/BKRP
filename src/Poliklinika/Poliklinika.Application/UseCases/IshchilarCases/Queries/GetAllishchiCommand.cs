using MediatR;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.IshchilarCases.Queries
{
    public class GetAllishchiCommand : IRequest<IEnumerable<Ishchi>>
    {
        public int Id { get; set; }
        public string Ism { get; set; }
        public string Familiya { get; set; }
        public string Lavozimi { get; set; }
        public string XonaNomi { get; set; }

    }
}
