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
        public IActionResult ViewRecipes([FromQuery] string[] category, [FromQuery] string name)

        {
            Predicate<Recipe> predicate = new Predicate<Recipe>(
                r =>
                (
                    category == null
                            ||
                    category.All(
                       c => r.Categories.Any(cat => cat.ID == c))
                )
                &&
                (
                    name == null
                    ||
                    r.Name.Contains(name)
                )
                );

            
            return View();
        }
        [Route("recipes/{recipe}")]
        public IActionResult ViewRecipe([FromRoute] string recipe)
        {
            var rec = _recipeService.Get(recipe);
            if (rec == null)
            {
                Response.StatusCode = 404;
                return View("Error", new ErrorViewModel() { Message = "It seems this recipe does not exist (yet or already)" });
            }
            return View("/Views/Recipes/ViewRecipe.cshtml",
               rec
                );
        }
    }
}
