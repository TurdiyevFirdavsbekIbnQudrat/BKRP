using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Domain.Entities
{
    [Table("Yer",Schema ="dbo")]
    public class Yer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Sotix")]
        public int sotix { get; set; }
        [Column("YerNarxiId")]
        public int YerNarxiId { get; set; }
        [ForeignKey("YerNarxiId")]
        public YerNarxi yerNarxi { get; set; }
        [Column("FoydalanuvchiId")]
        public int FoydalanuvchiId { get; set; }
        [ForeignKey("FoydalanuvchiId")]
        public Foydalanuvchi foydalanuvchi { get; set; }
    }
}
