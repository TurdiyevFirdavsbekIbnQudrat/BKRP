using Authorization.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.API.Models.BogchaModel
{
    [Table("BogchaAdminlar",Schema ="dbo")]
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
        public Role Role { get; set; }
    }
}
