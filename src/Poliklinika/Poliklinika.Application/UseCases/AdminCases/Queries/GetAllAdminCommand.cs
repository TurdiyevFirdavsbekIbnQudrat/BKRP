using MediatR;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.AdminCases.Queries
{
    public class GetAllAdminCommand : IRequest<IEnumerable<Admin>>
    {
        public int Id { get; set; }
        public string Parol { get; set; }
        public string UserName { get; set; }

    }
}
