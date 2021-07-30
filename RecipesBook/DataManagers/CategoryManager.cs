using Microsoft.EntityFrameworkCore;
using RecipesBook.DAL;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecipesBook.DataManagers
{
    public class CategoryManager : AbsractDataManager<Category>
    {
        public CategoryManager(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override void Create(Category entity)
        {
            if (entity != null)
            {
                DbContext.Categories.Add(entity);
                DbContext.SaveChanges();
            }
        }

        public override bool Delete(object key)
        {
            try
            {
                if (key != null)
                {
                    var entity = DbContext.Categories.Where(c => c.Id == key.ToString()).SingleOrDefault();
                    if (entity != null)
                    {
                        DbContext.Categories.Remove(entity);
                        DbContext.SaveChanges();
                        return true;
                    }
                }
            }
            catch (DbUpdateException)
            {
                return false;
            }
            return false;
        }

        public override bool Edit(object key, Category editedEntity)
        {
            try
            {
                if (key != null)
                {
                    var entity = DbContext.Categories.FirstOrDefault(c => c.Id == key.ToString());
                    entity.IsHidden = editedEntity.IsHidden;
                    entity.Description = editedEntity.Description;
                    entity.MainImage = editedEntity.MainImage;
                    entity.Name = editedEntity.Name;



                    DbContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception exe)
            {
                return false;
            }

        }

        public override Category Get(Func<Category, bool> predicate)
        {
            if (predicate != null)
            {
                return DbContext.Categories.AsNoTracking().SingleOrDefault(predicate);
            }
            return null;
        }

        public override Category Get(object key)
        {
            if (key != null)
            {
                return DbContext.Categories.AsNoTracking().Include(c => c.Recipes).ThenInclude(rc => rc.Recipe).ToList().SingleOrDefault(c => c.Id == key.ToString());
            }
            return null;
        }

        public override IList<Category> GetEntities<Parameter>(Func<Category, bool> predicate, Func<Category, Parameter> SortPredicate)
        {
            var filtered = DbContext.Categories.AsNoTracking();
            IEnumerable<Category> filteredCategory;
            if (predicate != null)
            {
                filteredCategory = filtered.Where(predicate);
            }
            else
            {
                filteredCategory = filtered.ToList();
            }
            if (SortPredicate != null)
            {
                filteredCategory.OrderBy(SortPredicate);
            }
            return filteredCategory.ToList();
        }

        public override IList<Category> GetEntities<Parameter>(Func<Category, Parameter> SortPredicate)
        {
            var filtered = DbContext.Categories.AsNoTracking();
            if (SortPredicate != null)
            {
                return filtered.OrderBy(SortPredicate).ToList();
            }
            return filtered.ToList();
        }

        public override IList<Category> GetEntities()
        {
            return DbContext.Categories.AsNoTracking().ToList();
        }

        public override IList<Category> GetEntities(Func<Category, bool> predicate)
        {
            if (predicate != null)
            {
                return DbContext.Categories.AsNoTracking().Where(predicate).ToList();
            }
            return DbContext.Categories.AsNoTracking().ToList();
        }
    }
}
