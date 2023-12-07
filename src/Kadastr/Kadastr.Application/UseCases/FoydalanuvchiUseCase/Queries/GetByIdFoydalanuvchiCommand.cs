using Kadastr.Domain.Entities;
using MediatR;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Queries
{
    public class GetByIdFoydalanuvchiCommand : IRequest<Foydalanuvchi>
    {
        public int Id { get; set; }
    }
}
