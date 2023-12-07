using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadastr.Domain.Entities
{
    [Table("YerNarxi",Schema ="dbo")]
    public class YerNarxi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Viloyat")]
        public string Viloyat { get; set; }
        [Column("YerNarx")]
        public int YerNarx { get; set; }
        public IEnumerable<Yer> yer { get; set; }
    }
}
