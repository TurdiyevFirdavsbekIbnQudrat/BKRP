using Bogcha.Domain.Entities;
using MediatR;

namespace Bogcha.Application.UseCases.TarbiyachiUseCases.Queries
{
    public class GetAllTarbiyachiCommand : IRequest<IEnumerable<Tarbiyachi>>
    {

        public int Id { get; set; }
        public string Ism { get; set; }
        public string Familiya { get; set; }
        public int GuruhId { get; set; }
    }
}
