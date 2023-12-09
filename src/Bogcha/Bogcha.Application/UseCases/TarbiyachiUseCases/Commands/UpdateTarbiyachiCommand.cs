using MediatR;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Commands
{
    public class UpdateTarbiyachiCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Ism { get; set; }
        public string Familiya { get; set; }

    }
}
