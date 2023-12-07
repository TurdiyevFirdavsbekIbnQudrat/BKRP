using Kadastr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.YerNarxiUseCases.Queries
{
    public class GetByIdYerNarxiCommand:IRequest<YerNarxi>
    {
    }
}
