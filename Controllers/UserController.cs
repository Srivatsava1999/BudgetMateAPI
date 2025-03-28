using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private UserServices _service;
        public UserController(UserServices service){
            _service=service;

        }
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_service.AllUsers());
        }
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<User> GetUserById(int id)
        {
            var user=_service.UserById(id);
            if (user==null)
                return NotFound();
            
            return Ok(user);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<User> CreateUser(User user)
        {
            _service.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new{ id=user.UserId}, user);
        }
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateUser(int id, User updateduser)
        {
            var user=_service.UpdateUser(id, updateduser);
            if(user==null)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteUser(int id)
        {
            var user=_service.DeleteUser(id);
            if(user==null)
                return NotFound();
            return NoContent();
        }
    }
}