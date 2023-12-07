using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadastr.Domain.Entities
{
    [Table("Foydalanuvchi",Schema ="dbo")]
    public class Foydalanuvchi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("FirstName")]
        public string FirstName {  get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Parol")]
        public string Parol {  get; set; }
        [Column("UserName")]
        public string UserName { get; set; }

        public IEnumerable<Yer> yer {  get; set; } 
    }
}
