using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Users")]
    public class User{
        [Key]
        public int UserId{ get; set;}
        [Required]
        public string Name{get;set;}
        [Required]
        public string Password{get;set;}
        public string Phone{get;set;}
        public DateTime CreationDate{get;set;}=DateTime.UtcNow;
    }
}