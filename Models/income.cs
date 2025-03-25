using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models{
    [Table("Income")]
    public class Income{
        [Key]
        public int IncomeId{get;set;}
        public string IncomeName{get;set;}
        [Required]
        public int IncomeAmount{get;set;}
        [Required]
        public DateTime IncomeDate{get;set;}=DateTime.UtcNow;
        [Required]
        public DateTime IncomeMonth{get;set;}=new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
        public string IncomeDescription{get;set;}
        public bool RecurringFlag{get;set;}
        // Foreign Keys
        public int BudgetId{get;set;}
        public Budget Budget{get;set;}

    }
}