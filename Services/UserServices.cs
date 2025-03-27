using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Services{
    public class UserServices{
        private readonly AppDbContext _context;
        private BudgetServices _BudgetService;
        public UserServices(AppDbContext context, BudgetServices BudgetService){
            _context=context;
            _BudgetService=BudgetService;
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
            var BudgetToDelete=_context.Budget.Where(b=>b.UserId==id).ToList();
            _context.Users.Remove(user);
            if (BudgetToDelete.Count()>0)
                _context.Budget.RemoveRange(BudgetToDelete);
            _context.SaveChanges();
            return user;
        }
    }
}