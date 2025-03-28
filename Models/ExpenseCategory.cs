using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models{
    [Table("ExpenseCategory")]
    public class ExpenseCategory{
        [Key]
        public int CategoryId{get;set;}
        [Required]
        public string Name{get;set;}
    }
}