using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using System.Collections.Generic;
using System.Linq;

namespace api.Services{
    public class UserServices{
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context){
            _context=context;
        }
        public List<User> UserAll(){
            var users=_context.Users.ToList();
            return users;
        }
        public User UserById(int id){
            var user = _context.Users.Find(id);
            if(user==null)
                return null;
            
            return user;
        }
        public Void CreateUser(User user){
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User UpdateUser(int id,User updates){
            var user=_context.Users.Find(id);
            if(user==null)
                return null;
            user.Name=updates.Name;
            user.Password=updates.Password;
            user.Phone=updates.Phone;
            user.Email=updates.Email;

            _context.SaveChanges();
            return user;
        }
        public User DeleteUser(int id){
            var user=_context.Users.Find(id);
            if(user==null)
                return null;
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }
    }
}