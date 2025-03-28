using System.ComponentModel.DataAnnotations;

namespace api.DTO{
    public class RegisterRequest{
        public string Email{get;set;}
        public string Password{get;set;}
        public string Phone{get;set;}
    }
}