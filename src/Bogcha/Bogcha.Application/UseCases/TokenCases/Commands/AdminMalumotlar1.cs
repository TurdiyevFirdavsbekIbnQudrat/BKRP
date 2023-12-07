using Bogcha.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogcha.Application.UseCases.TokenCases.Commands
{
    public class AdminMalumotlar1:IRequest<IEnumerable<Admin>>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
