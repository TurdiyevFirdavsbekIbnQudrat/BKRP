using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Queries
{
    public class GetByIdTarbiyachiCommand : IRequest<Tarbiyachi>
    {
        public int Id { get; set; }
    }
}
