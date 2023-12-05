using MediatR;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Commands
{
    public class CreateShifokorIshKunlariCommand:IRequest<ShifokorIshKunlari>
    {
        public string Dushanba { get; set; }
        public string Seshanba { get; set; }
        public string Chorshanba { get; set; }
        public string Payshanba { get; set; }
        public string Juma { get; set; }
        public string Shanba { get; set; }
        public int IshchId { get; set; }


    }
}
