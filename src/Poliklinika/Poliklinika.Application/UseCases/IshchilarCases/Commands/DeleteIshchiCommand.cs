using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Application.UseCases.IshchilarCases.Commands
{
    public class DeleteIshchiCommand:IRequest<string>
    {
        public int id { get; set; }
    }
}
