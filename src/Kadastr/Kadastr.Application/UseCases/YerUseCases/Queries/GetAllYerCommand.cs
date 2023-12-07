using Kadastr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.YerUseCases.Queries
{
    public class GetAllYerCommand:IRequest<IEnumerable<Yer>>
    {
        public int Id { get; set; }
        public int sotix { get; set; }
        public int YerNarxiId { get; set; }
        public int FoydalanuvchiId { get; set; }
    }
}
