using MediatR;

namespace Poliklinika.Application.UseCases.ShifokorlarIshKunlariCases.Commands
{
    public class UpdateShifokorIshKunlariCommand:IRequest<string>
    {
        public int Id { get; set; }
        public string Dushanba { get; set; }
        public string Seshanba { get; set; }
        public string Chorshanba { get; set; }
        public string Payshanba { get; set; }
        public string Juma { get; set; }
        public string Shanba { get; set; }
    }
}
