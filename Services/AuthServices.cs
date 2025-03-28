using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using api.Models;
using api.DTO;
using api.Data;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace api.Services{
    public class AuthServices{
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<User> _hasher
        public AuthServices(AppDbContext context, IConfiguration config){
            _context=context;
            _config=config;
            _hasher=new PasswordHasher<User>();
        }
        public LoginResponse Login(LoginRequest request){
            var user=_context.User.SingleOrDefault(u=>u.Email==request.Email);
            if(user==null)
                return null;
            var result=_hasher.VerifyHashedPassword(user, user.Password, Request.Password);
            if(result!=PasswordVerificationResult.Success)
                return null;
            var AccessToken=GenerateAccessToken(user);
            return new LoginResponse
            {
                AccessToken=AccessToken,
                UserId=user.UserId,
                Email=user.Email
            }; 
        }
        private string GenerateJwtToken(User user)
        {
            var key=_config["jwtKey"];
            var issuer=_config["jwtIssuer"];
            var audience=_config["jwtAudience"];
            var claims= new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials=new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token=new JwtSecurityToken(
                issuer:issuer,
                audience:audience,
                claims:claims,
                expires:DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public LoginResponse Register(RegisterRequest request){
            var ExistingUser=_context.User.FirstOrDefault(u=>u.Email==request.Email);
            if (ExistingUser!=null)
                return null;
            
            var user=new User
            {
                Email=request.Email,
                Name=request.Name,
                Phone=request.Phone
            };
            user.Password = _hasher.HashPassword(user, request.Password);
        }
    }
    
}