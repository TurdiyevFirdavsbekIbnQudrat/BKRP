using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Authorization.API.Enums;

namespace Authorization.API.Models.PoliklinikaModel
{
    [Table("AdminPoliklinika",Schema ="dbo")]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Parol")]
        public string Parol { get; set; }

        [Column("UserName")]
        public string Username { get; set; }
        [Column("Role")]
        public Role role { get ; set; }

    }
}
