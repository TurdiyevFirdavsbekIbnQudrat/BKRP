using Kadastr.Domain.Entities;
using MediatR;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Commands.UpdateCommand
{
    public class UpdateFoydalanuvchiCommand : IRequest<string>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Parol { get; set; }
        public string UserName { get; set; }
    }
}
