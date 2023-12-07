using Kadastr.Domain.Entities;
using MediatR;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Commands
{
    public class CreateYerNarxiCommand:IRequest<YerNarxi>
    {
        public string Viloyat { get; set; }
        public int YerNarx { get; set; }
    }
}
