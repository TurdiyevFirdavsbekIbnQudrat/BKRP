using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bogcha.Domain.Entities
{
    [Table("Davomat",Schema ="dbo")]
    public class Davomat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Ishtirok")]
        public int ishtirok { get; set; }
        [Column("BolaId")]
        public int BolaId { get; set; }
        [ForeignKey("BolaId")]
        public Bola bola { get; set; }
    }
}
