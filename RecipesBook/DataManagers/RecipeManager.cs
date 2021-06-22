using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
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

        public override Recipe Get(Predicate<Recipe> predicate)
        {
           var e= base.Get(predicate);
            if (e != null)
            {

            }
            return e;
        }



        public override IList<Recipe> GetEntities()
        {
            return base.GetEntities();
        }
        public override IList<Recipe> GetEntities(Predicate<Recipe> predicate)
        {
            return base.GetEntities();
            //return Entities.Where(x => predicate.Invoke(x)).ToList();
        }



        protected override void Seed()
        {
            Entities.Add(new Recipe()
            {
                Name = "Apple bisquid",
                Description = "Yeah",
                Id = "1",
                Ingredients = new string[] { "copper-30gramm" },
                Categories = new Category[] {
                    new Category() { Id="1" },
                    new Category() { Id = "2" },
                    new Category() { Id = "3" },
                    new Category() { Id = "4" },
                    new Category() { Id = "5" }

                },
                UsersThatLiked = new User[] { },
                Steps = new Step[] { },
                MainImage = null
            });
            Entities.Add(new Recipe()
            {
                Name = "Apple blossom",
                Description = "Yeah",
                Id = "2",
                Ingredients = new string[] { "copper-30gramm" },
                Categories = new Category[] {
                    new Category() { Id="1" },
                    new Category() { Id = "2" },
                    new Category() { Id = "3" },
                    new Category() { Id = "4" },
                    new Category() { Id = "5" }

                },
                UsersThatLiked = new User[] { },
                Steps = new Step[] { },
                MainImage = null
            });
            Entities.Add(new Recipe()
            {
                Name = "Apple from apple",
                Description = "Yeah",
                Id = "3",
                Ingredients = new string[] { "copper-30gramm" },
                Categories = new Category[] {
                    new Category() { Id="1" },
                    new Category() { Id = "2" },
                    new Category() { Id = "3" },
                    new Category() { Id = "4" },
                    new Category() { Id = "5" }

                },
                UsersThatLiked = new User[] { },
                Steps = new Step[] { },
                MainImage = null
            });
            Entities.Add(new Recipe()
            {
                Name = "Apple dydy",
                Description = "Yeah",
                Id = "4",
                Ingredients = new string[] { "copper-30gramm" },
                Categories = new Category[] {
                    new Category() { Id="1" },
                    new Category() { Id = "2" },
                    new Category() { Id = "3" },
                    new Category() { Id = "4" },
                    new Category() { Id = "5" }

                },
                UsersThatLiked = new User[] { },
                Steps = new Step[] { },
                MainImage = null
            });
            Entities.Add(new Recipe()
            {
                Name = "Apple trish",
                Description = "Yeah",
                Id = "5",
                Ingredients = new string[] { "copper-30gramm" },
                Categories = new Category[] {
                    new Category() { Id="1" },
                    new Category() { Id = "2" },
                    new Category() { Id = "3" },
                    new Category() { Id = "4" },
                    new Category() { Id = "5" }

                },
                UsersThatLiked = new User[] { },
                Steps = new Step[] { },
                MainImage = null
            });
        }
    }
}
