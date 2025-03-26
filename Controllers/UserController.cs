using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using System.Collections.Generic;
using System.Linq

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly AppDbContext _context;
        public UserContoller(AppDbContext context)
        {
            _context=context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users=_context.Users.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if(user==null)
                return NotFound();
            
            return Ok(user);
        }
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new{ id=user.UserId}, user);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var user=_context.Users.Find(id);
            if(user==null)
                return NotFound();
            
            user.Name=updatedUser.Name;
            user.Password=updatedUser.Password;
            user.Phone=updatedUser.Phone;
            user.Email=updatedUser.Email;

            _context.SaveChnages();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        [
            var user=_context.Users.Find(id);
            if(user==null)
                return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        ]
    }
}