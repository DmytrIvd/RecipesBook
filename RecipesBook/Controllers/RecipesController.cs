using Microsoft.AspNetCore.Mvc;
using RecipesBook.DataManagers;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IDataManager<Recipe> _recipeService;
        public RecipesController(IDataManager<Recipe> recipes)
        {
            _recipeService = recipes;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("recipes/{recipe}")]
        public IActionResult ViewRecipe([FromRoute] string recipe)
        {

            return View("/Views/Recipes/ViewRecipe.cshtml", new Recipe()
            {
                Name = "Dish" + recipe,
                Description = "Description" + recipe,
                Ingredients = new string[] {
                                "1-1 gram",
                                "2 -2 grams",
                                "3 -3 grams",
                                "4 -4 grams",
                                "5 -5 grams"
                 },
                Categories = new Category[]
                {
                    new Category(){Id="1",Name="Something1"},
                    new Category(){Id="2",Name="Something2"},
                    new Category(){Id="3",Name="Something3"},
                    new Category(){Id="4",Name="Something4"},
                }
            });
        }
    }
}
