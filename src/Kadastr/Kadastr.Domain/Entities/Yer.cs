using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Domain.Entities
{
    [Table("Yer")]
    public class Yer
    {
        public int Id { get; set; }
        public int sotix { get; set; }
        public int YerNarxiId { get; set; }
        public YerNarxi yerNarxi { get; set; }
        public int FoydalanuvchiId { get; set; }
        public Foydalanuvchi foydalanuvchi { get; set; }
    }
}
