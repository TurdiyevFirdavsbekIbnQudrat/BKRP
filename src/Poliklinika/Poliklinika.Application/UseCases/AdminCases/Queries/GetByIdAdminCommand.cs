using MediatR;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.AdminCases.Queries
{
    public class GetByIdAdminCommand : IRequest<Admin>
    {
        public int id { get; set; }
    }
}
