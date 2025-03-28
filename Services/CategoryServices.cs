using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using api.Services;
using System.Collections.Generic;
using System.Linq;

namespace api.Services{
    public class CategoryServices{
        private readonly AppDbContext _context;
        public CategoryServices(AppDbContext context){
            _context=context;
        }
        public List<ExpenseCategory> AllCategories(){
            var Categories=_context.ExpenseCategory.ToList();
            return Categories;
        }
    }
}