﻿using Bogcha.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bogcha.Domain.Entities
{
    [Table("Tarbiyachi",Schema ="dbo")]
    public class Tarbiyachi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Ism")]
        public string Ism { get; set; }
        [Column("Familiya")]
        public string Familiya { get; set; }
        [Column("Role")]
        public Role role { get; set; }
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("Password")]
        public string Password { get; set; }

        [Column("GuruhId")]
        public int GuruhId { get; set; }
        [ForeignKey("GuruhId")]
        public Guruh guruh { get; set; }
        
        public IEnumerable<Davomat> davomat { get; set; }
    }
}
