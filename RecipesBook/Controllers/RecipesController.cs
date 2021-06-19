using Microsoft.AspNetCore.Mvc;
using RecipesBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("recipes/{recipe}")]
        public IActionResult ViewRecipe([FromRoute] string recipe)
        {

            return View("/Views/Recipes/ViewRecipe.cshtml", new RecipeViewModel()
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
                Categories = new CategoryViewModel[]
                {
                    new CategoryViewModel(){Id="1",Name="Something1"},
                    new CategoryViewModel(){Id="2",Name="Something2"},
                    new CategoryViewModel(){Id="3",Name="Something3"},
                    new CategoryViewModel(){Id="4",Name="Something4"},
                }
            });
        }
    }
}
