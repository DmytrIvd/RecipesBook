using Microsoft.AspNetCore.Mvc;
using RecipesBook.DataManagers;
using RecipesBook.Models;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IDataManager<Category> _categoryService;
        private readonly IDataManager<Recipe> _recipeService;

        public CategoryController(IDataManager<Category> categories, IDataManager<Recipe> recipes)
        {
            _categoryService = categories;
            _recipeService = recipes;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("category/{category}")]
        public IActionResult ViewCategory([FromRoute] string category)
        {
            var cat = _categoryService.Get(category, loadReferences: true);
           
            if (cat == null)
            {
                Response.StatusCode = 404;
                return View("Error", new ErrorViewModel() { Message = "It seems this category does not exist (yet or already)" });

            }
            for (int i = 0; i < cat.Recipes.Length; i++)
            {
                cat.Recipes[i] = _recipeService.Get(cat.Recipes[i].ID);
            }
            return View("/Views/Category/ViewCategory.cshtml",
              cat); ;
        }
    }
}
