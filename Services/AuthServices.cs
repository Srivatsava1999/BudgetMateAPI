using System.IdetityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using api.Models;
using api.DTO;
using api.Data;
using System.Linq;

namespace api.Services{
    public class AuthServices{
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public AuthServices(AppDbContext context, IConfiguration config){
            _context=context;
            _config=config;
        }
        public LoginResponse Login(LoginRequest request){
            var user=_context.User.Where(u=>u.Email==request.Email && u.Password==request.Password);
            if(user==null)
                return null;
            var AccessToken=GenerateAccessToken(user);
            return new LoginResponse
            {
                AccessToken=AccessToken,
                UserId=user.UserId,
                Email=user.Email
            }; 
        }
        public List GenerateJwtToken(User user)
        {
            var key=_config["jwtKey"];
            var issuer=_config["jwtIssuer"];
            var audience=_config["jwtAudience"];
            var claims= new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JWTRegisteredClaimNames.Email, user.Email),
                new Claim(JWTRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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
    }
    
}