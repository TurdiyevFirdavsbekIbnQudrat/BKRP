using MediatR;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.KunVaVaqtlarCases.Commands
{
    public class CreateKunVaVaqtCommand : IRequest<KunVaVaqt>
    {
        public string Vaqt { get; set; }

    }
}
