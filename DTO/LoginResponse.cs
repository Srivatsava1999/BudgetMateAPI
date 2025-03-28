using System.ComponentBuilder.DataAnnotations;

namespace api.DTO{
    public class LoginResponse{
        public string AccessToken{get;set;}
        public int UserId{get;set;}
        public string Email{get;set;}
    }
}