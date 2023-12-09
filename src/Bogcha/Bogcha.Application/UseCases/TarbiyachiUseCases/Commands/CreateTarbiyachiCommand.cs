using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Commands
{
    public class CreateTarbiyachiCommand:IRequest<Tarbiyachi>
    {
        public string Ism { get; set; }
        public string Familiya { get; set; }

    }
}
