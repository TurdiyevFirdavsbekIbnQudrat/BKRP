using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bogcha.Domain.Entities
{
    [Table("Bola" ,Schema ="dbo")]
    public class Bola
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Ism")]
        public string Ism { get; set; }

        [Column("Familiya")]
        public string Familiya { get; set; }

        [Column("GuruhId")]
        public int GuruhId { get; set; }
        [ForeignKey("GuruhId")]
        public Guruh guruh { get; set; }
        
        public IEnumerable<Davomat> davomat { get; set; }


    }
}
