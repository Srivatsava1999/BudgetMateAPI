using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api.Data;
using api.Models;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExpenseController:ControllerBase{
        private ExpenseServices _service;
        public ExpenseController(ExpenseServices service){
            _service=service;
        }
        [HttpGet("{BudgetId}")]
        [Authorize]
        public ActionResult<IEnumerable<Expense>> GetExpenses(int BudgetId){
            return Ok(_service.AllExpense(BudgetId));
        }
        [HttpGet("{Expenseid}/{BudgetId}")]
        [Authorize]
        public ActionResult<Expense> GetExpenseById(int Expenseid,int BudgetId)
        {
            var Expense=_service.ExpenseById(BudgetId,Expenseid);
            if (Expense==null)
                return NotFound();
            
            return Ok(Expense);
        }
        [HttpPost]
        [Authorize]
        public ActionResult<Expense> CreateExpense(Expense Expense)
        {
            _service.CreateExpense(Expense);
            return CreatedAtAction(nameof(GetExpenseById), new{ Expenseid=Expense.ExpenseId, BudgetId=Expense.BudgetId}, Expense);
        }
        [HttpPut("{Expenseid}")]
        [Authorize]
        public IActionResult UpdateExpense(int Expenseid, Expense updatedExpense)
        {
            var Expense=_service.UpdateExpense(Expenseid, updatedExpense);
            if(Expense==null)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{Expenseid}")]
        [Authorize]
        public IActionResult DeleteExpense(int Expenseid)
        {
            var Expense=_service.DeleteExpense(Expenseid);
            if(Expense==null)
                return NotFound();
            return NoContent();
        }
    }
}