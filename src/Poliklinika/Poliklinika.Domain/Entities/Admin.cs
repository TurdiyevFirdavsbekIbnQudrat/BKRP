﻿
using Poliklinika.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Poliklinika.Domain.Entities
{
    [Table("Admin", Schema = "dbo")]
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
        public Role role { get; set; }
    }
}
