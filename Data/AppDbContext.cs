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
		public DbSet<User> users{get; set;}
		public DbSet<Budget> Budget{get; set;}
		public DbSet<Income> Income{get; set;}
		public DbSet<Expense> Expense{get;set;}
		public DbSet<Saving> Saving{get;set;}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Budget>().Property(b=>b.TotalIncome).HasDefaultValue(0);
			modelBuilder.Entity<Budget>().Property(b=>b.TotalExpense).HasDefaultValue(0);
			modelBuilder.Entity<Income>().Property(i=>i.IncomeAmount).HasDefaultValue(0);
			modelBuilder.Entity<Income>().Property(i=>i.RecurringFlag).HasDefaultValue(false);
			modelBuilder.Entity<Expense>().Property(e=>e.RecurringFlag).HasDefaultValue(false);
			modelBuilder.Entity<Saving>().Property(s=>s.TotalSave).HasDefaultValue(0);
			modelBuilder.Entity<User>().Entity<User>().HasIndex(u=>u.Email).IsUnique();
		}
	}
	
}