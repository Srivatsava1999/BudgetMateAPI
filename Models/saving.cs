using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models{
    [Table("Saving")]
    public class Saving{
        [Key]
        public int SavingId{get;set;}
        public int TotalSave{get;set;}
        // Foreign Key
        public int BudgetId{get;set;}
        public Budget Budget{get;set;}
    }
}