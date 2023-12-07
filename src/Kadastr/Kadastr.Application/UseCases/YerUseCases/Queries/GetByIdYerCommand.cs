using Kadastr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.YerUseCases.Queries
{
    public class GetByIdYerCommand:IRequest<Yer>
    {
        public int Id
        {
            get; set;
        }
        
    }
}
