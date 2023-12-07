using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadastr.Domain.Entities
{

    [Table("Rollar", Schema = "dbo")]
    public class Rollar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Parol")]
        public string Parol { get; set; }
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("Role")]
        public string Role { get; set; }
    }
}
