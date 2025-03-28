using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Conroller{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: BaseController{
        [HttpPost("login")]
        public IActionResult Login()
    }
}