using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Services{
    public class ExpenseServices{
        private readonly AppDbContext _context;
        private BudgetServices _BudgetService;
        public ExpenseServices(AppDbContext context){
            _context=context;
            _BudgetService=BudgetService;
        }
        public List<Expense> AllExpense(int BudgetId){
            var ExpensePlan=_context.Expense.Where(i=>i.BudgetId==BudgetId).ToList();
            return ExpensePlan ?? new List<Budget>();
        }
        public Expense ExpenseById(int budgetid, int Expenseid){
            var ExpensePlan=_context.Expense.Find(Expenseid);
            if(ExpensePlan==null)
                return null;
            return ExpensePlan;
        }
        public void CreateExpense(Expense Expense){
            _context.Expense.Add(Expense);
            var BudgetPlan=_context.Budget.Find(Expense.BudgetId);
            BudgetPlan.TotalExpense=BudgetPlan.TotalExpense+Expense.ExpenseAmount;
            _BudgetService.UpdateBudget(Expense.BudgetId, BudgetPlan);
            _context.SaveChanges();
        }
        public Expense UpdateExpense(int id, Expense updates){
            var Expense=_context.Expense.Find(id);
            if (Expense==null)
                return null;
            
            Expense.ExpenseName=updates.ExpenseName;
            Expense.ExpenseAmount=updates.ExpenseAmount;
            Expense.ExpenseCategory=updates.ExpenseCategory;
            Expense.ExpenseDescription=updates.ExpenseDescription;
            Expense.ExpenseDate=updates.ExpenseDate;
            Expense.RecurringFlag=updates.RecurringFlag;
            var BudgetPlan=_context.Budget.Find(Expense.BudgetId);
            BudgetPlan.TotalExpense=BudgetPlan.TotalExpense+Expense.ExpenseAmount;
            _BudgetService.UpdateBudget(Expense.BudgetId, BudgetPlan);

            _context.SaveChanges();
            return Expense;
        }
        public Expense DeleteExpense(int id){
            var Expense=_context.Expense.Find(id);
            if (Expense==null)
                return null;
            var BudgetPlan=_context.Budget.Find(Expense.BudgetId);
            BudgetPlan.TotalExpense=BudgetPlan.TotalExpense-Expense.ExpenseAmount;
            _BudgetService.UpdateBudget(Expense.BudgetId, BudgetPlan);
            _context.Expense.Remove(Expense);
            _context.SaveChanges();
            return Expense;
        }
    }
}