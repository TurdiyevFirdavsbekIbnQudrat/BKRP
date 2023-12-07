using Kadastr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.YerUseCases.Commands
{
    public class UpdateYerCommand:IRequest<string>
    {

        public int Id { get; set; }
        public int sotix { get; set; }
        public int YerNarxiId { get; set; }
        public int FoydalanuvchiId { get; set; }
    }
}
