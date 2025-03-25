using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models{
    [Table("Budget")]
    public class Budget{
        [Key]
        public int BudgetId{ get; set;}
        [Required]
        public DateTime BudgetMonth{get;set;}=new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
        public int TotalIncome{get;set;}
        public int TotalExpense{get;set;}
        public int MonthlyNet{get;set;}
        // Foriegn Key
        public int UserId{get;set;}
        public User User{get;set;}

    }
}
