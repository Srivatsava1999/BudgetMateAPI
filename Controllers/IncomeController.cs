using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController:ControllerBase{
        private IncomeServices _service;
        public IncomeController(IncomeServices service){
            _service=service;
        }
        [HttpGet("{BudgetId}")]
        [Authorize]
        public ActionResult<IEnumerable<Income>> GetIncomes(int BudgetId){
            return Ok(_service.AllIncome(BudgetId));
        }
        [HttpGet("{Incomeid}/{BudgetId}")]
        [Authorize]
        public ActionResult<Income> GetIncomeById(int Incomeid,int BudgetId)
        {
            var Income=_service.IncomeById(BudgetId,Incomeid);
            if (Income==null)
                return NotFound();
            
            return Ok(Income);
        }
        [HttpPost]
        [Authorize]
        public ActionResult<Income> CreateIncome(Income Income)
        {
            _service.CreateIncome(Income);
            return CreatedAtAction(nameof(GetIncomeById), new{ Incomeid=Income.IncomeId, BudgetId=Income.BudgetId}, Income);
        }
        [HttpPut("{Incomeid}")]
        [Authorize]
        public IActionResult UpdateIncome(int Incomeid, Income updatedIncome)
        {
            var Income=_service.UpdateIncome(Incomeid, updatedIncome);
            if(Income==null)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{Incomeid}")]
        [Authorize]
        public IActionResult DeleteIncome(int Incomeid)
        {
            var Income=_service.DeleteIncome(Incomeid);
            if(Income==null)
                return NotFound();
            return NoContent();
        }
    }
}