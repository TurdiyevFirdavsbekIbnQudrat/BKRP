using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.YerUseCases.Commands
{
    public class DeleteYerCommand:IRequest<string>
    {
        public int Id { get; set; }
    }
}
