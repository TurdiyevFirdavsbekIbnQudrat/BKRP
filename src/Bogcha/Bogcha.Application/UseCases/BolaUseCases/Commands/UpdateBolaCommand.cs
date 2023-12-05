using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogcha.Application.UseCases.BolaUseCases.Commands
{
    public class UpdateBolaCommand:IRequest<string>
    {
        public int Id { get; set; }
        public string Ism { get; set; }
        public string Familiya { get; set; }
        public string GuruhId { get; set; }
    }
}
