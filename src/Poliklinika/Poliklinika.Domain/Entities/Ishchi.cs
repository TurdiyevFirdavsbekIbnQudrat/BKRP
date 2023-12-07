using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poliklinika.Domain.Entities
{

    [Table("Ishchi", Schema = "dbo")]
    public class Ishchi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Ism")]
        public string Ism { get; set; }

        [Column("Familiya")]
        public string Familiya { get; set; }

        [Column("Lavozimi")]
        public string Lavozimi {  get; set; }

        [Column("XonaNomi")]
        public string XonaNomi { get; set; }
        
        public ShifokorIshKunlari shifokorIshKunlari { get; set; }
       }
}
