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

        


    }
}
