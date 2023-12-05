using MediatR;
using Poliklinika.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poliklinika.Application.UseCases.AdminCases.Commands
{
    public class CreateAdminCommand : IRequest<Admin>
    {
        
        public string Parol { get; set; }
        public string UserName { get; set; }

    }
}
