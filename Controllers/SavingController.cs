using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class SavingController:ControllerBase{
        private SavingServices _service;
        public SavingController(SavingServices service){
            _service=service;
        }
        [HttpGet("{BudgetId}")]
        public ActionResult<IEnumerable<Saving>> GetSavings(int BudgetId){
            return Ok(_service.AllSaving(BudgetId));
        }
        [HttpGet("{Savingid}/{BudgetId}")]
        public ActionResult<Saving> GetSavingById(int Savingid,int BudgetId)
        {
            var Saving=_service.SavingById(BudgetId,Savingid);
            if (Saving==null)
                return NotFound();
            
            return Ok(Saving);
        }
        [HttpPost]
        public ActionResult<Saving> CreateSaving(Saving Saving)
        {
            _service.CreateSaving(Saving);
            return CreatedAtAction(nameof(GetSavingById), new{ Savingid=Saving.SavingId, BudgetId=Saving.BudgetId}, Saving);
        }
        [HttpPut("{Savingid}")]
        public IActionResult UpdateSaving(int Savingid, Saving updatedSaving)
        {
            var Saving=_service.UpdateSaving(Savingid, updatedSaving);
            if(Saving==null)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{Savingid}")]
        public IActionResult DeleteSaving(int Savingid)
        {
            var Saving=_service.DeleteSaving(Savingid);
            if(Saving==null)
                return NotFound();
            return NoContent();
        }
    }
}