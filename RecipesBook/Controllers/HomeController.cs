using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipesBook.DataManagers;
using RecipesBook.Models;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataManager<Recipe> _recipeService;
        private readonly IDataManager<Category> _categoryService;

        public HomeController(IDataManager<Recipe> Recipes, IDataManager<Category> Categories)
        {
            _recipeService = Recipes;
            _categoryService = Categories;
        }
        [Route("")]
        [Route("Home")]
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            ViewData["Categories"] = _categoryService.GetEntities(SortPredicate: (category) => category.DateOfAdd).Take(5);
            ViewData["Recipes"] = _recipeService.GetEntities(SortPredicate: (recipe) => recipe.DateOfAdd).Take(10);
            return View();
        }
        [Route("[controller]/[action]")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("[controller]/[action]")]
        public IActionResult About()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
