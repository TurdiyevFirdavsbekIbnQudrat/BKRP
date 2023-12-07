using Kadastr.Domain.Entities;
using MediatR;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Commands
{
    public class DeleteYerNarxiCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
