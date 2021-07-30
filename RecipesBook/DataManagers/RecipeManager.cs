using Microsoft.EntityFrameworkCore;
using RecipesBook.DAL;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecipesBook.DataManagers
{
    public class RecipeManager : AbsractDataManager<Recipe>
    {
        public RecipeManager(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override void Create(Recipe entity)
        {
            if (entity != null)
            {
                foreach (var category in entity.Categories)
                {
                    category.Category = DbContext.Categories.Find(category.Category.Id);
                }
                DbContext.Recipes.Add(entity);

                DbContext.SaveChanges();
            }

        }

        public override bool Delete(object key)
        {

            try
            {
                if (key != null)
                {
                    var entity = DbContext.Recipes.Where(r => r.Id == key.ToString()).SingleOrDefault();
                    if (entity != null)
                    {
                        DbContext.Recipes.Remove(entity);
                        DbContext.SaveChanges();
                        return true;
                    }
                }
            }
            catch (DbUpdateException upd)
            {
                return false;
            }
            return false;
        }

        public override bool Edit(object key, Recipe editedEntity)
        {
            try
            {
                if (key != null)
                {
                    var entity = DbContext.Recipes.
                        Include(r => r.Steps).
                        Include(r => r.Categories).
                        ToList().SingleOrDefault(r => r.Id == key.ToString());

                    entity.Description = editedEntity.Description;
                    entity.Ingredients = editedEntity.Ingredients;

                    //entity.Categories = editedEntity.Categories;
                    var categoriesToDelete = entity.Categories.Where(c => !editedEntity.Categories.Contains(c));
                    foreach (var cat in categoriesToDelete)
                    {
                        entity.Categories
                            .Remove(cat);
                    }

                    foreach (var category in editedEntity.Categories)
                    {
                        //For a new CategoryRecipes
                        if (!entity.Categories.Any(rc => rc.Equals(category)))
                        {
                            //category.Category= DbContext.Categories.Find(category.Category.Id);
                            entity.Categories.Add(category);

                        }


                    }


                    var stepstoDelete = entity.Steps.Where(s => !editedEntity.Steps.Contains(s));
                    foreach (var step in stepstoDelete)
                    {
                        //DbContext.Steps.Remove(step);
                        entity.Steps.Remove(step);
                    }
                    foreach (var editedStep in editedEntity.Steps)
                    {
                        if (editedStep.Id != null)
                        {
                            var stepToEdit = entity.Steps.First(s => s.Id == editedStep.Id);
                            if (stepToEdit.Img != editedStep.Img)
                                stepToEdit.Img = editedStep.Img;
                            if (stepToEdit.Text != editedStep.Text)
                                stepToEdit.Text = editedStep.Text;

                        }
                        else
                        {
                            entity.Steps.Add(editedStep);
                        }
                    }

                    entity.UsersThatLiked = editedEntity.UsersThatLiked;

                    DbContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (DbUpdateException upd)
            {
                return false;
            }
        }

        public override Recipe Get(Func<Recipe, bool> predicate)
        {
            if (predicate != null)
            {
                return DbContext.Recipes.AsNoTracking().ToList().SingleOrDefault(predicate);
            }
            return null;
        }

        public override Recipe Get(object key)
        {
            if (key != null)
            {
                return DbContext.Recipes.
                    Include(r => r.Steps).
                    Include(r => r.Categories).
                    ThenInclude(rc => rc.Category).
                    AsNoTracking().ToList().SingleOrDefault(r => r.Id == key.ToString());
            }
            return null;
        }

        public override IList<Recipe> GetEntities<Parameter>(Func<Recipe, bool> predicate, Func<Recipe, Parameter> SortPredicate)
        {
            var filtered = DbContext.Recipes.Include(r => r.Categories).AsNoTracking();
            IEnumerable<Recipe> filteredRecipes;
            if (predicate != null)
            {
                filteredRecipes = filtered.Where(predicate);
            }
            else
            {
                filteredRecipes = filtered.ToList();
            }
            if (SortPredicate != null)
            {
                filteredRecipes.OrderBy(SortPredicate);
            }
            return filteredRecipes.ToList();
        }

        public override IList<Recipe> GetEntities<Parameter>(Func<Recipe, Parameter> SortPredicate)
        {
            var filtered = DbContext.Recipes.AsNoTracking();
            if (SortPredicate != null)
            {
                return filtered.OrderBy(SortPredicate).ToList();
            }
            return filtered.ToList();
        }

        public override IList<Recipe> GetEntities()
        {
            return DbContext.Recipes.AsNoTracking().ToList();
        }

        public override IList<Recipe> GetEntities(Func<Recipe, bool> predicate)
        {
            if (predicate != null)
            {
                return DbContext.Recipes.AsNoTracking().Where(predicate).ToList();
            }
            return DbContext.Recipes.AsNoTracking().ToList();
        }
    }
}
