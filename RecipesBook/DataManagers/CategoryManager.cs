using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipesBook.DataManagers
{
    public class CategoryManager : AbsractDataManager<Category>
    {

        public CategoryManager()
        {

        }

        public override Category Get(object key, bool loadReferences = false)
        {
            var category = base.Get(key, loadReferences);

            return category;
        }
        public override Category Get(Predicate<Category> predicate, bool loadReferences = false)
        {
            var category = base.Get(predicate, loadReferences);

            return category;
        }
        public override IList<Category> GetEntities(bool loadReferences = false, Func<Category, object> SortPredicate = null)
        {
            var category = base.GetEntities(loadReferences, SortPredicate);

            return category;
        }
        public override IList<Category> GetEntities(Predicate<Category> predicate, bool loadReferences = false, Func<Category, object> SortPredicate = null)
        {
            var category = base.GetEntities(predicate, loadReferences, SortPredicate);

            return category;
        }

        protected override void Seed()
        {
            Entities.Add(new Category()
            {
                Id = "1",
                Name = "1",
                Description = "description1",
                DateOfAdd = DateTime.Now,
                Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            });
            Entities.Add(new Category()
            {
                Id = "2",
                Name = "2",
                Description = "description2",
                DateOfAdd = DateTime.Now,
                Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            });
            Entities.Add(new Category()
            {
                Id = "3",
                Name = "3",
                Description = "description3",
                DateOfAdd = DateTime.Now,
                Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            });
            Entities.Add(new Category()
            {
                Id = "4",
                Name = "4",
                Description = "description4",
                DateOfAdd = DateTime.Now,
                Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            });
            Entities.Add(new Category()
            {
                Id = "5",
                Name = "5",
                Description = "description5",
                DateOfAdd = DateTime.Now,
                Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            });

        }
    }
}
