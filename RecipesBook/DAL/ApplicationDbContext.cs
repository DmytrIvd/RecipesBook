using Microsoft.EntityFrameworkCore;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryRecipe> CategoryRecipes { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Step> Steps { get; set; }

        public DbSet<RecipeUser> RecipeUsers { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Ignore(c => c.ID);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Category>().HasMany(c => c.Recipes);

            modelBuilder.Entity<CategoryRecipe>().HasKey(cr => new { cr.CategoryId, cr.RecipeId });
            
            modelBuilder.Entity<Recipe>().HasKey(r => r.Id);
            modelBuilder.Entity<Step>().HasKey(r => r.Id);

            modelBuilder.Entity<RecipeUser>().HasKey(ru => new { ru.RecipeId, ru.UserId });

            modelBuilder.Entity<User>().HasKey(u => u.Email);
            //base.OnModelCreating(modelBuilder);
        }
    }
}
