using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Services{
    public class BudgetServices{
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public BudgetServices(AppDbContext context, IServiceProvider serviceProvider){
            _context=context;
            _serviceProvider=serviceProvider;
        }
        public List<Budget> AllBudget(int UserId){
            var BudgetPlan=_context.Budget.Where(b=>b.UserId==UserId).ToList();
            return BudgetPlan ?? new List<Budget>();
        }
        public Budget BudgetById(int userid, int budgetid){
            var BudgetPlan=_context.Budget.Find(budgetid);
            if(BudgetPlan==null)
                return null;
            return BudgetPlan;
        }
        public void CreateBudget(Budget budget){
            _context.Budget.Add(budget);
            _context.SaveChanges();
        }
        public Budget UpdateBudget(int id, Budget updates){
            var budget=_context.Budget.Find(id);
            if (budget==null)
                return null;
            
            budget.TotalIncome=updates.TotalIncome;
            budget.TotalExpense=updates.TotalExpense;
            budget.MonthlyNet=updates.TotalIncome - updates.TotalExpense;
            var SavingAccount=_context.Saving.SingleOrDefault(s=>s.BudgetId==budget.BudgetId);
            var savingService = _serviceProvider.GetService<SavingServices>();
            savingService?.UpdateSaving(SavingAccount.SavingId, SavingAccount);
            _context.SaveChanges();
            return budget;
        }
        public Budget DeleteBudget(int id){
            var budget=_context.Budget.Find(id);
            if (budget==null)
                return null;
            var IncomeToDelete=_context.Income.Where(i=>i.BudgetId==id).ToList();
            var ExpenseToDelete=_context.Expense.Where(e=>e.BudgetId==id).ToList();
            var SavingToDelete=_context.Saving.Where(s=>s.BudgetId==id).ToList();
            _context.Budget.Remove(budget);
            if (IncomeToDelete.Count()>0)
                _context.Income.RemoveRange(IncomeToDelete);
            if (ExpenseToDelete.Count()>0)
                _context.Expense.RemoveRange(ExpenseToDelete);
            if (SavingToDelete.Count()>0)
                _context.Saving.RemoveRange(SavingToDelete);
            _context.SaveChanges();
            return budget;
        }

    }
}