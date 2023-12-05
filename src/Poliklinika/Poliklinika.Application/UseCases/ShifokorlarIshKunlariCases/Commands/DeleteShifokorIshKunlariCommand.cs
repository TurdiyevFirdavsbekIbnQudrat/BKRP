using MediatR;

namespace Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Commands
{
    public class DeleteShifokorIshKunlariCommand:IRequest<string>
    {
        public int Id { get; set; }
    }
}
