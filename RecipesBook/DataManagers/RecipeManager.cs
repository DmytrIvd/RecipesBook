using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecipesBook.DataManagers
{
    public class RecipeManager : AbsractDataManager<Recipe>
    {
        private readonly IDataManager<Category> _categoryService;
        private readonly IDataManager<Step> _stepsService;

        public RecipeManager(IDataManager<Category> categoryDataManager, IDataManager<Step> stepDataManager) : base()
        {
            _categoryService = categoryDataManager;
            _stepsService = stepDataManager;

        }

        public override Recipe Get(object key, bool loadReferences = false)
        {
            var recipe = base.Get(key);
                      return recipe;
        }
        public override Recipe Get(Func<Recipe, bool> predicate, bool loadReferences = false)
        {
            var e = base.Get(predicate);
           
            return e;
        }

        public override IList<Recipe> GetEntities<Parameter>(bool loadReferences = false, Func<Recipe, Parameter> SortPredicate = null)
        {
            var entities = base.GetEntities(loadReferences, SortPredicate);

           
            return entities;
        }
        public override IList<Recipe> GetEntities<Parameter>(Func<Recipe, bool> predicate, bool loadReferences = false, Func<Recipe, Parameter> SortPredicate = null)
        {
            var entities = base.GetEntities(predicate, loadReferences, SortPredicate);

        
            return entities;
            //return Entities.Where(x => predicate.Invoke(x)).ToList();
        }


        public override bool Delete(object key)
        {
            return base.Delete(key);
            //var entity = Entities.SingleOrDefault(e => e.ID == key.ToString());
            //if (entity != null)
            //{
            //    if (base.Delete(key))
            //    {
            //        foreach (var c in entity.Categories)
            //        {
            //            var category = _categoryService.Get(c.Id);
            //            var list = category.Recipes.ToList();
            //            list.RemoveAll(r => r.Id == entity.Id);
            //            category.Recipes = list.ToArray();
            //            _categoryService.Edit(category.Id, category);
            //        }
            //        return true;
            //    }

            //}
            //return false;
        }

        public override bool Edit(object key, Recipe editedEntity)
        {
            //var Originalentity = Entities.SingleOrDefault(e => e.ID == key.ToString());
            //if (Originalentity != null)
            //{

            //    if (base.Edit(key, editedEntity))
            //    {
            //        var deletedCategories = Originalentity.Categories.Where(c => !editedEntity.Categories.Contains(c)).Select(c => c.CategoryId);
            //        foreach (var c in deletedCategories)
            //        {
            //            var category = _categoryService.Get(c);
            //            var list = category.Recipes.ToList();
            //            list.RemoveAll(r => r.RecipeId == Originalentity.Id);
            //            category.Recipes = list.ToArray();
            //            _categoryService.Edit(category.Id, category);
            //        }

            //        var deletedSteps = Originalentity.Steps.Where(c => !editedEntity.Steps.Contains(c)).Select(c => c.Id);
            //        foreach (var s in deletedSteps)
            //        {
            //            _stepsService.Delete(s);
            //        }
            //        return true;
            //    }
            //}
            //return false;
            return base.Edit(key, editedEntity);
        }

        protected override void Seed()
        {
            //string filename = "./wwwroot/images/NotFound.png";
            //byte[] bytes = null;
            //using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            //{
            //    // Create a byte array of file stream length
            //    bytes = System.IO.File.ReadAllBytes(filename);
            //    //Read block of bytes from stream into the byte array
            //    fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            //    //Close the File Stream
            //    fs.Close();
            //}
            //Entities.Add(new Recipe()
            //{
            //    Name = "Apple bisquid",
            //    Description = "Yeah",
            //    Id = "1",
            //    DateOfAdd = DateTime.Now,
            //    Ingredients = new string[] { "copper-30gramm" },
            //    Categories = new Category[] {
            //        new Category() { Id="1" },
            //        new Category() { Id = "2" },


            //    },
            //    UsersThatLiked = new User[] { },
            //    Steps = new Step[] {

            //        new Step() { Id = "3" },
            //        new Step() { Id = "4" },
            //        new Step() { Id = "5" }
            //    },
            //    MainImage = bytes
            //});
            //Entities.Add(new Recipe()
            //{
            //    Name = "Apple blossom",
            //    Description = "Yeah",
            //    Id = "2",
            //    DateOfAdd = DateTime.Now,
            //    Ingredients = new string[] { "copper-30gramm" },
            //    Categories = new Category[] {
            //        new Category() { Id="1" },
            //        new Category() { Id = "2" },

            //    },
            //    UsersThatLiked = new User[] { },
            //    Steps = new Step[] { },
            //    MainImage = bytes
            //});
            //Entities.Add(new Recipe()
            //{
            //    Name = "Apple from apple",
            //    Description = "Yeah",
            //    Id = "3",
            //    DateOfAdd = DateTime.Now,
            //    Ingredients = new string[] { "copper-30gramm" },
            //    Categories = new Category[] {
            //        new Category() { Id="1" }

            //    },
            //    UsersThatLiked = new User[] { },
            //    Steps = new Step[] { },
            //    MainImage = bytes
            //});
            //Entities.Add(new Recipe()
            //{
            //    Name = "Apple dydy",
            //    Description = "Yeah",
            //    Id = "4",
            //    DateOfAdd = new DateTime(1993, 9, 21),
            //    Ingredients = new string[] { "copper-30gramm" },
            //    Categories = new Category[] {

            //        new Category() { Id = "5" }

            //    },
            //    UsersThatLiked = new User[] { },
            //    Steps = new Step[] { },
            //    MainImage = bytes
            //});
            //Entities.Add(new Recipe()
            //{
            //    Name = "Apple trish",
            //    Description = "Yeah",
            //    Id = "5",
            //    DateOfAdd = DateTime.Now,
            //    Ingredients = new string[] { "copper-30gramm" },
            //    Categories = new Category[] {
            //        new Category() { Id="1" },
            //        new Category() { Id = "2" },

            //    },
            //    UsersThatLiked = new User[] { },
            //    Steps = new Step[] { },
            //    MainImage = bytes
            //});
        }
    }
}
