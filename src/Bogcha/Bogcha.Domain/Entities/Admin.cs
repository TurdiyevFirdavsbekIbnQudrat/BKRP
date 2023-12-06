using System.ComponentModel.DataAnnotations.Schema;

namespace Bogcha.Domain.Entities
{
    [Table("Adminlar",Schema ="dbo")]
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("Role")]
        public string Role { get; set; }
    }
}
