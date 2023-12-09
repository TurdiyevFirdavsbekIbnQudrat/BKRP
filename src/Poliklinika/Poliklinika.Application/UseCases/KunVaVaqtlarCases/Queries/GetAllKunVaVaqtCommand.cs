using MediatR;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.KunVaVaqtlarCases.Queries
{
    public class GetAllKunVaVaqtCommand:IRequest<IEnumerable<KunVaVaqt>>
    {
        public int Id { get; set; }
        public string Vaqt { get; set; }
        public string Kun { get; set; }
    }
}
