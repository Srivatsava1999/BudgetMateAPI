using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Data;

namespace api.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{
		}
		public DbSet<User> User{get; set;}
		public DbSet<Budget> Budget{get; set;}
		public DbSet<Income> Income{get; set;}
		public DbSet<Expense> Expense{get;set;}
		public DbSet<Saving> Saving{get;set;}
		public DbSet<ExpenseCategory> ExpenseCategory{get;set;}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Budget>().Property(b=>b.TotalIncome).HasDefaultValue(0);
			modelBuilder.Entity<Budget>().Property(b=>b.TotalExpense).HasDefaultValue(0);
			modelBuilder.Entity<Income>().Property(i=>i.IncomeAmount).HasDefaultValue(0);
			modelBuilder.Entity<Income>().Property(i=>i.RecurringFlag).HasDefaultValue(false);
			modelBuilder.Entity<Expense>().Property(e=>e.RecurringFlag).HasDefaultValue(false);
			modelBuilder.Entity<Saving>().Property(s=>s.TotalSave).HasDefaultValue(0);
			modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();
			modelBuilder.Entity<ExpenseCategory>().HasData(
				new ExpenseCategory{ CategoryId=1, Name="Rent/Mortgage"},
				new ExpenseCategory{ CategoryId=2, Name="Utilities"},
				new ExpenseCategory{ CategoryId=3, Name="Groceries"},
				new ExpenseCategory{ CategoryId=4, Name="Junk Foods"},
				new ExpenseCategory{ CategoryId=5, Name="Dining Out"},
				new ExpenseCategory{ CategoryId=6, Name="Healthcare"},
				new ExpenseCategory{ CategoryId=7, Name="Transportation"},
				new ExpenseCategory{ CategoryId=8, Name="Insurance"},
				new ExpenseCategory{ CategoryId=9, Name="Entertainment"},
				new ExpenseCategory{ CategoryId=10, Name="Education"},
				new ExpenseCategory{ CategoryId=11, Name="Retail"},
				new ExpenseCategory{ CategoryId=12, Name="Grooming/Personal Care"},
				new ExpenseCategory{ CategoryId=13, Name="Other"}
			);
		}
	}
	
}