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
        private readonly IDataManager<Category> _categoryService;
        private readonly IDataManager<Step> _stepService;

        public RecipesController(IDataManager<Recipe> recipes, IDataManager<Category> categories, IDataManager<Step> steps)
        {
            _recipeService = recipes;
            _categoryService = categories;
            _stepService = steps;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("recipes/{recipe}")]
        public IActionResult ViewRecipe([FromRoute] string recipe)
        {
            var rec = _recipeService.Get(recipe, loadReferences: true);
            if (rec == null)
            {
                Response.StatusCode = 404;
                return View("Error", new ErrorViewModel() { Message = "It seems this recipe does not exist (yet or already)" });
            }
            return View("/Views/Recipes/ViewRecipe.cshtml",
               rec
                );
        }
        [Route("uploadRecipe")]
        [HttpPost]
        public IActionResult UploadRecipe(Recipe recipe)
        {

            if (ModelState.IsValid)
            {
                _recipeService.Create(recipe);

                return RedirectToAction("ViewRecipe", "Recipes", recipe.ID);
            }

            return View();


        }
        [Route("uploadRecipe")]
        [HttpGet]
        public IActionResult UploadRecipe()
        {
            if (ViewData["categories"] == null)
            {
                ViewData["categories"] = _categoryService.GetEntities(SortPredicate: (c) => c.Name);
            }
            return View();
        }
    }
}
