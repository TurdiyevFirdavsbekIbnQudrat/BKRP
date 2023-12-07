using MediatR;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Commands
{
    public class UpdateYerNarxiCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Viloyat { get; set; }
        public int YerNarx { get; set; }

    }
}
