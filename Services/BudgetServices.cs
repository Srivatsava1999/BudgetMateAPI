using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using System.Collections.Generic;
using System.Linq;

namespace api.Services{
    public class BudgetServices{
        private readonly AppDbContext _context;
        public BudgetServices(AppDbContext context){
            _context=context;
        }
        public List<Budget> AllBudget(int UserId){
            var BudgetPlan=_context.Budget.Where(b=>b.UserId==UserId).ToList();
            if (BudgetPlan==null)
                return null;

            return BudgetPlan;
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

            _context.SaveChanges();
            return budget;
        }
        public Budget DeleteBudget(int id){
            var budget=_context.Budget.Find(id);
            if (budget==null)
                return null;
            
            _context.Budget.Remove(budget);
            _context.SaveChanges();
            return budget;
        }
    }
}