using Kadastr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Application.UseCases.FoydalanuvchiUseCase.Queries
{
    public class GetAllFoydalanuvchiCommand:IRequest<IEnumerable<Foydalanuvchi>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Parol { get; set; }
        public string UserName { get; set; }
    }
}
