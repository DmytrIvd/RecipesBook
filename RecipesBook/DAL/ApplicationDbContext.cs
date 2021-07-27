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
            #region User
            modelBuilder.Entity<User>().Ignore(u => u.ID);

            modelBuilder.Entity<User>().HasKey(u => u.Email);

            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();

            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            #endregion
            #region Recipe
            modelBuilder.Entity<Recipe>().HasKey(r => r.Id);
            modelBuilder.Entity<Recipe>().Ignore(r => r.ID);
            modelBuilder.Entity<Recipe>().Ignore(r => r.Ingredients);

            modelBuilder.Entity<Recipe>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Recipe>().Property(r => r.Name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Recipe>().Property(r => r.Description).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Recipe>().Property(r => r.DateOfAdd).IsRequired();
            modelBuilder.Entity<Recipe>().Property(r => r.StringIngredients).IsRequired();
            modelBuilder.Entity<Recipe>().Property(r => r.MainImage).IsRequired();

            modelBuilder.Entity<Recipe>().HasOne(r => r.Author).WithMany(u => u.CreatedRecipes);

            #endregion
            #region RecipeUser(Liked recipes)
            modelBuilder.Entity<RecipeUser>().HasKey(ru => new { ru.RecipeId, ru.UserId });
            modelBuilder.Entity<RecipeUser>().HasOne(ru => ru.Recipe).WithMany(r => r.UsersThatLiked);
            modelBuilder.Entity<RecipeUser>().HasOne(ru => ru.User).WithMany(u => u.LikedRecipes);
            #endregion
            #region Step
            modelBuilder.Entity<Step>().HasKey(s => s.Id);
            modelBuilder.Entity<Step>().Ignore(s => s.ID);

            modelBuilder.Entity<Step>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Step>().Property(s => s.Img).IsRequired();
            modelBuilder.Entity<Step>().Property(s => s.Text).HasMaxLength(800).IsRequired();

            modelBuilder.Entity<Step>().HasOne(s => s.Recipe).WithMany(r => r.Steps).OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region Category
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Ignore(c => c.ID);

            modelBuilder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.DateOfAdd).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Description).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.IsHidden).HasDefaultValue(false);
            modelBuilder.Entity<Category>().Property(c => c.MainImage).IsRequired();

            #endregion
            #region RecipeCategory
            modelBuilder.Entity<CategoryRecipe>().HasKey((cr) => new { cr.CategoryId, cr.RecipeId });
            modelBuilder.Entity<CategoryRecipe>().HasOne((cr) => cr.Category).WithMany(c => c.Recipes).HasForeignKey(cr => cr.CategoryId);
            modelBuilder.Entity<CategoryRecipe>().HasOne(cr => cr.Recipe).WithMany(r => r.Categories).HasForeignKey(cr => cr.RecipeId);
            #endregion
            modelBuilder.Entity<CategoryRecipe>().HasKey(cr => new { cr.CategoryId, cr.RecipeId });





            //base.OnModelCreating(modelBuilder);
        }
    }
}
