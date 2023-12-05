using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poliklinika.Domain.Entities
{
    [Table("KunVaVaqt", Schema = "dbo")]

    public class KunVaVaqt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        [Column("Id")]
        public int Id { get; set; }
        
        [Column("Vaqt")]
        public string Vaqt { get; set; }
        
        [Column("Kun")]
        public string Kun { get; set; }
        
        
        [Column("ShifokorIshKunlariId")]
        public int ShifokorIshKunlarId { get; set; }
        [ForeignKey("ShifokorIshKunlarId")]
        public ShifokorIshKunlari shifokorIshKunlari { get; set; }
    }
}
