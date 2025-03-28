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
    public class CategoryController:ControllerBase{
        private CategoryServices _service;
        public CategoryController(CategoryServices service){
            _service=service;
        }
    [HttpGet]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ExpenseCategory>> GetCategories(){
        return Ok(_service.AllCategories());
    }
    }
}