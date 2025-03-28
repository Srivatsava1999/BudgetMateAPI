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
    public class SavingController:ControllerBase{
        private SavingServices _service;
        public SavingController(SavingServices service){
            _service=service;
        }
        [HttpGet("{BudgetId}")]
        [Authorize]
        public ActionResult<IEnumerable<Saving>> GetSavings(int BudgetId){
            return Ok(_service.AllSaving(BudgetId));
        }
        [HttpGet("{Savingid}/{BudgetId}")]
        [Authorize]
        public ActionResult<Saving> GetSavingById(int Savingid,int BudgetId)
        {
            var Saving=_service.SavingById(BudgetId,Savingid);
            if (Saving==null)
                return NotFound();
            
            return Ok(Saving);
        }
        [HttpPost]
        [Authorize]
        public ActionResult<Saving> CreateSaving(Saving Saving)
        {
            _service.CreateSaving(Saving);
            return CreatedAtAction(nameof(GetSavingById), new{ Savingid=Saving.SavingId, BudgetId=Saving.BudgetId}, Saving);
        }
        [HttpPut("{Savingid}")]
        [Authorize]
        public IActionResult UpdateSaving(int Savingid, Saving updatedSaving)
        {
            var Saving=_service.UpdateSaving(Savingid, updatedSaving);
            if(Saving==null)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{Savingid}")]
        [Authorize]
        public IActionResult DeleteSaving(int Savingid)
        {
            var Saving=_service.DeleteSaving(Savingid);
            if(Saving==null)
                return NotFound();
            return NoContent();
        }
    }
}