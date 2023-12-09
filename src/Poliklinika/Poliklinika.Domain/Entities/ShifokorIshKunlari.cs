using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poliklinika.Domain.Entities
{
    [Table("ShifokorIshKunlari", Schema = "dbo")]
    public class ShifokorIshKunlari
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Dushanba")]
        public string Dushanba { get; set; }
        [Column("Seshanba")]
        public string Seshanba { get; set; }
        [Column("Chorshanba")]
        public string Chorshanba { get; set; }
        [Column("Payshanba")]
        public string Payshanba { get; set; }
        [Column("Juma")]
        public string Juma { get; set; }
        [Column("Shanba")]
        public string Shanba { get; set; }

    }

}
