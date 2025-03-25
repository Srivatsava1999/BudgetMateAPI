using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models{
    [Table("Expense")]
    public class Expense{
        [Key]
        public int ExpenseId{get;set;}
        public string ExpenseName{get;set;}
        [Required]
        public int ExpenseAmount{get;set;}
        [Required]
        public DateTime ExpenseMonth{get;set;}=new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
        [Required]
        public DateTime ExpenseDate{get;set;}=DateTime.UtcNow;
        [Required]
        public required string ExpenseCategory{get;set;}
        public string ExpenseDescription{get;set;}
        public bool RecurringFlag{get;set;}
        // Foreign Key
        public int BudgetId{get;set;}
        public Budget Budget{get;set;}
    }
}