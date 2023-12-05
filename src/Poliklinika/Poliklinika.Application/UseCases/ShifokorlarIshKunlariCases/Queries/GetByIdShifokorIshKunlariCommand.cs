using MediatR;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Queries
{
    public class GetByIdShifokorIshKunlariCommand:IRequest<ShifokorIshKunlari>
    {
        public int Id { get; set; }
    }
}
