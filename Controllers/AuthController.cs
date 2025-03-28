using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api.Data;
using api.Models;
using api.Services;
using api.DTO;
using System.Collections.Generic;
using System.Linq;

namespace api.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase{
        private readonly AuthServices _services;
        public AuthController(AuthServices service){
            _services=service;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult<LoginRequest> Login([FromBody]LoginRequest Request){
            var Response=_services.Login(Request);
            if(Response==null)
                return Unauthorized("Invalid email or password");
            
            return Ok(Response);
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public ActionResult<LoginResponse> Register([FromBody] RegisterRequest request){
            var response=_services.Register(request);
            if(response==null)
                return BadRequest("user with this email already exists");
            return Ok(response);
        }
    }
}