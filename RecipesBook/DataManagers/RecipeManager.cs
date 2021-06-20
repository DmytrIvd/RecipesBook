using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipesBook.DataManagers
{
    public class RecipeManager : IDataManager<Recipe>
    {
        private readonly IDataManager<Category> _categoryService;
        private readonly IDataManager<Step> _stepsService;
        private IList<Recipe> _recipes;
        public RecipeManager(IDataManager<Category> categoryDataManager, IDataManager<Step> stepDataManager)
        {
            _categoryService = categoryDataManager;
            _stepsService = stepDataManager;
            _recipes = new List<Recipe>();
        }
        public void Create(Recipe entity)
        {
            _recipes.Add(entity);
        }

        public bool Delete(object key)
        {
            return _recipes.Remove(new Recipe() { Id = key.ToString() });
            //_recipes.RemoveAt(_recipes.ToList().FindIndex(r => r.Id));
        }

        public bool Edit(object key, Recipe editedEntity)
        {
            var r = _recipes.SingleOrDefault(r => r.Id.Equals(key));
            if (r != default)
            {
                //Change
                r = editedEntity;
            }
            return false;
        }


        public Recipe Get(object key)
        {
            var r = _recipes.SingleOrDefault(r => r.Id.Equals(key));
            if (r != default)
            {
                for (int i = 0; i < r.Categories.Length; i++)
                {
                    r.Categories[0] = _categoryService.Get(r.Categories[0].Id);
                }
                for (int i = 0; i < r.Steps.Length; i++)
                {
                    r.Steps[0] = _stepsService.Get(r.Steps[0].Id);
                }
            }
            return r;
        }

        public Recipe Get(Predicate<Recipe> predicate)
        {
            return _recipes.SingleOrDefault(x => predicate.Invoke(x));
        }

        public IList<Recipe> GetEntities()
        {
            return _recipes.ToList();
        }
        public IList<Recipe> GetEntities(Predicate<Recipe> predicate)
        {
            return _recipes.Where(x => predicate.Invoke(x)).ToList();
        }
    }
}
