using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NutritionTrackerServer.Models;

namespace NutritionTrackerServer.Data
{
    public class IngredientDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;
        public IngredientDbContext(DbContextOptions<IngredientDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ingredient> Ingredient { set; get; }
        public DbSet<User> Users { set; get; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(GetIngredients());
            modelBuilder.Entity<User>().ToTable("Users");
            base.OnModelCreating(modelBuilder);
        }

        private List<Ingredient> GetIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient {Id = 1, IngredientName = "Eggs", Calories = 90, Fats = 10, Protein = 20, Sugar = 0, Carbs = 0},
                new Ingredient {Id = 2, IngredientName = "Tuna Fish", Calories = 60, Fats = 0, Protein = 36, Sugar = 0, Carbs = 0},
                new Ingredient {Id = 3, IngredientName = "Oat Meal", Calories = 120, Fats = 5, Protein = 8, Sugar = 0, Carbs = 45}
            };
            
        }
        
         //private List<User> GetUsers()
         //   {
         //       return new List<User>
         //   {
         //       new User {Id = 1, Username = "username", Password = "password"}               
         //   };

         //   }

        //*******************************************************************************
        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        }

        //*******************************************************************************
        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();

                await (_currentTransaction?.CommitAsync() ?? Task.CompletedTask);
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        //*******************************************************************************
        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

    }// end class
}// end namespace
