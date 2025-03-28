using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Services{
    public class SavingServices{
        private readonly AppDbContext _context;
        private BudgetServices _BudgetService;
        public SavingServices(AppDbContext context, BudgetServices BudgetService){
            _context=context;
            _BudgetService=BudgetService;
        }
        public List<Saving> AllSaving(int BudgetId){
            var SavingAccount=_context.Saving.Where(i=>i.BudgetId==BudgetId).ToList();
            return SavingAccount ?? new List<Saving>();
        }
        public Saving SavingById(int budgetid, int Savingid){
            var SavingAccount=_context.Saving.Find(Savingid);
            if(SavingAccount==null)
                return null;
            return SavingAccount;
        }
        public void CreateSaving(Saving Saving){
            _context.Saving.Add(Saving);
            _context.SaveChanges();
        }
        public Saving UpdateSaving(int id, Saving updates){
            var Saving=_context.Saving.Find(id);
            if (Saving==null)
                return null;

            var BudgetPlan=_context.Budget.Find(updates.BudgetId);
            Saving.TotalSave=Saving.TotalSave + BudgetPlan.MonthlyNet;


            _context.SaveChanges();
            return Saving;
        }
        public Saving DeleteSaving(int id){
            var Saving=_context.Saving.Find(id);
            if (Saving==null)
                return null;
            
            _context.Saving.Remove(Saving);
            _context.SaveChanges();
            return Saving;
        }
    }
}