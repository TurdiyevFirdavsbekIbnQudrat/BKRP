using Kadastr.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Commands.CreateCommand
{
    public class CreateFoydalanuvchiCommand : IRequest<Foydalanuvchi>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Parol { get; set; }
        public string UserName { get; set; }
    }
}
