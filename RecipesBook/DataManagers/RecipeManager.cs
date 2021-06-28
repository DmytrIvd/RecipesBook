﻿using RecipesBook.Models.Entities;
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
        protected virtual void LoadCategoryReferences(Recipe recipe)
        {

            if (recipe != null && recipe.Categories != null)
            {
                for (int i = 0; i < recipe.Categories.Length; i++)
                {
                    recipe.Categories[i] = _categoryService.Get(recipe.Categories[i].ID);
                }
            }
        }
        protected virtual void LoadStepsReferences(Recipe recipe)
        {
            if (recipe != null && recipe.Steps != null)
            {
                for (int i = 0; i < recipe.Steps.Length; i++)
                {
                    recipe.Steps[i] = _stepsService.Get(recipe.Steps[i].ID);
                }
            }
        }
        public override Recipe Get(object key, bool loadReferences = false)
        {
            var recipe = base.Get(key);
            if (loadReferences)
            {

                LoadCategoryReferences(recipe);
                LoadStepsReferences(recipe);
            }
            return recipe;
        }
        public override Recipe Get(Func<Recipe, bool> predicate, bool loadReferences = false)
        {
            var e = base.Get(predicate);
            if (loadReferences)
            {
                LoadCategoryReferences(e);
                LoadStepsReferences(e);
            }
            return e;
        }
        public override IList<Recipe> GetEntities<Parameter>(bool loadReferences = false, Func<Recipe, Parameter> SortPredicate = null)
        {
            var entities = base.GetEntities(loadReferences, SortPredicate);

            if (loadReferences)
            {
                foreach (var e in entities)
                {
                    LoadCategoryReferences(e);
                    LoadStepsReferences(e);
                }
            }
            return entities;
        }
        public override IList<Recipe> GetEntities<Parameter>(Func<Recipe, bool> predicate, bool loadReferences = false, Func<Recipe, Parameter> SortPredicate = null)
        {
            var entities = base.GetEntities(predicate, loadReferences, SortPredicate);

            if (loadReferences)
            {
                foreach (var e in entities)
                {
                    LoadCategoryReferences(e);
                    LoadStepsReferences(e);
                }
            }
            return entities;
            //return Entities.Where(x => predicate.Invoke(x)).ToList();
        }



        protected override void Seed()
        {
            Entities.Add(new Recipe()
            {
                Name = "Apple bisquid",
                Description = "Yeah",
                Id = "1",
                DateOfAdd = DateTime.Now,
                Ingredients = new string[] { "copper-30gramm" },
                Categories = new Category[] {
                    new Category() { Id="1" },
                    new Category() { Id = "2" },
                    new Category() { Id = "3" },
                    new Category() { Id = "4" },
                    new Category() { Id = "5" }

                },
                UsersThatLiked = new User[] { },
                Steps = new Step[] {
                    new Step() { Id="1" },
                    new Step() { Id = "2" },
                    new Step() { Id = "3" },
                    new Step() { Id = "4" },
                    new Step() { Id = "5" }
                },
                MainImage = null
            });
            Entities.Add(new Recipe()
            {
                Name = "Apple blossom",
                Description = "Yeah",
                Id = "2",
                DateOfAdd = DateTime.Now,
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
                DateOfAdd = DateTime.Now,
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
                DateOfAdd = new DateTime(1993, 9, 21),
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
                DateOfAdd = DateTime.Now,
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
