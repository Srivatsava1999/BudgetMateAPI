using System.ComponentModel.DataAnnotations;

namespace api.DTO{
    public class RegisterRequest{
        public string Email{get;set;}
        public int Password{get;set;}
        public string Name{get;set;}
        public string Phone{get;set;}
    }
}