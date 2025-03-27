using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Services;
using System.Collections.Generics;
using Sytem.Linq;

namespace api.Services{
    public class IncomeServices{
        private readonly AppDbContext _context;
        private BudgetServices _BudgetService;
        public IncomeServices(AppDbContext context, BudgetServices BudgetService){
            _context=context;
            _BudgetService=BudgetService;
        }
        public List<Income> AllIncome(int BudgetId){
            var IncomePlan=_context.Income.Where(i=>i.BudgetId==BudgetId).ToList();
            if (IncomePlan==null)
                return null;

            return IncomePlan;
        }
        public Income IncomeById(int budgetid, int Incomeid){
            var IncomePlan=_context.Income.Find(Incomeid);
            if(IncomePlan==null)
                return null;
            return IncomePlan;
        }
        public void CreateIncome(Income Income){
            _context.Income.Add(Income);
            var BudgetPlan=_context.Budget.Find(Income.BudgetId);
            BudgetPlan.TotalIncome=BudgetPlan.TotalIncome+Income.IncomeAmount;
            _BudgetPlan.UpdateBudget(Income.BudgetId, BudgetPlan);
            _context.SaveChanges();
        }
        public Income UpdateIncome(int id, Income updates){
            var Income=_context.Income.Find(id);
            if (Income==null)
                return null;
            
            Income.IncomeName=updates.IncomeName;
            Income.IncomeAmount=updates.IncomeAmount;
            Income.IncomeDescription=updates.IncomeDescription;
            Income.IncomeDate=updates.IncomeDate;
            Income.RecurringFlag=updates.RecurringFlag;
            var BudgetPlan=_context.Budget.Find(Income.BudgetId);
            BudgetPlan.TotalIncome=BudgetPlan.TotalIncome+Income.IncomeAmount;
            _BudgetPlan.UpdateBudget(Income.BudgetId, BudgetPlan);
            _context.SaveChanges();
            return Income;
        }
        public Income DeleteIncome(int id){
            var Income=_context.Income.Find(id);
            if (Income==null)
                return null;
            var BudgetPlan=_context.Budget.Find(Income.BudgetId);
            BudgetPlan.TotalIncome=BudgetPlan.TotalIncome-Income.IncomeAmount;
            _BudgetPlan.UpdateBudget(Income.BudgetId, BudgetPlan);
            _context.Income.Remove(Income);
            _context.SaveChanges();
            return Income;
        }
    }
}