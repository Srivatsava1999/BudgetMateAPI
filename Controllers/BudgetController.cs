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
    public class BudgetController:ControllerBase{
        private BudgetServices _service;
        public BudgetController(BudgetServices service){
            _service=service;
        }
        [HttpGet("{userid}")]
        [Authorize]
        public ActionResult<IEnumerable<Budget>> GetBudgets(int userid){
            return Ok(_service.AllBudget(userid));
        }
        [HttpGet("{budgetid}/{userid}")]
        [Authorize]
        public ActionResult<Budget> GetBudgetById(int budgetid,int userid)
        {
            var budget=_service.BudgetById(userid,budgetid);
            if (budget==null)
                return NotFound();
            
            return Ok(budget);
        }
        [HttpPost]
        [Authorize]
        public ActionResult<Budget> CreateBudget(Budget budget)
        {
            _service.CreateBudget(budget);
            return CreatedAtAction(nameof(GetBudgetById), new{ budgetid=budget.BudgetId, userid=budget.UserId}, budget);
        }
        [HttpPut("{budgetid}")]
        [Authorize]
        public IActionResult UpdateBudget(int budgetid, Budget updatedbudget)
        {
            var budget=_service.UpdateBudget(budgetid, updatedbudget);
            if(budget==null)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{budgetid}")]
        [Authorize]
        public IActionResult DeleteBudget(int budgetid)
        {
            var budget=_service.DeleteBudget(budgetid);
            if(budget==null)
                return NotFound();
            return NoContent();
        }
    }
}