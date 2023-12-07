using Kadastr.Domain.Entities;
using MediatR;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Queries
{
    public class GetAllYerNarxiCommand : IRequest<IEnumerable<YerNarxi>>
    {

        public int Id { get; set; }
        public string Viloyat { get; set; }
        public int YerNarx { get; set; }
    }
}
