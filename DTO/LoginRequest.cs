using System.ComponentBuilder.DataAnnotations;

namespace api.DTO{
    public class LoginRequest
    {
        [Required]
        [Email Address]
        public string Email{get;set;}

        [Required]
        public string Password{get;set;}
    }
}