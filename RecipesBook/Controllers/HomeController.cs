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
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Categories = _categoryService.GetEntities(SortPredicate: (category) => category.DateOfAdd).Take(5),
                Recipes = _recipeService.GetEntities(SortPredicate: (recipe) => recipe.DateOfAdd).Take(10)
            };

            return View(homeViewModel);
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


        #region Category Search
        [HttpPost]
        public IActionResult SearchCategory(SearchCategoryViewModel categorySearch)
        {

            categorySearch.filteredCategories = _categoryService.GetEntities((c) => categorySearch.search == null || c.Name.Contains(categorySearch.search), SortPredicate: (c) => c.DateOfAdd);
            return View(categorySearch);
        }
        [HttpGet]
        public IActionResult SearchCategory()
        {
            SearchCategoryViewModel searchCategoryViewModel = new SearchCategoryViewModel
            {
                search = null,
                filteredCategories = _categoryService.GetEntities(SortPredicate: c => c.DateOfAdd)
            };
            return View(searchCategoryViewModel);
        }



        #endregion

        #region Recipe Search
        [HttpPost]
        public IActionResult SearchRecipe(SearchRecipeViewModel searchRecipe)
        {
            searchRecipe.AllCategories = _categoryService.GetEntities(SortPredicate: (c) => c.DateOfAdd);
            Func<Recipe, bool> filter = new Func<Recipe, bool>(
                (r) =>
                (searchRecipe.search == null
                ||
                r.Name.Contains(searchRecipe.search)) &&
                (searchRecipe.filteredCategories == null
                ||
                r.Categories.Any(c => searchRecipe.filteredCategories.Contains(c.Id))));


            searchRecipe.FilteredRecipes =
                _recipeService.GetEntities(filter, SortPredicate: (recipe) => recipe.DateOfAdd);
            return View(searchRecipe);
        }
        [HttpGet]
        public IActionResult SearchRecipe()
        {
            SearchRecipeViewModel searchRecipe = new SearchRecipeViewModel
            {
                AllCategories = _categoryService.GetEntities(SortPredicate: (c) => c.DateOfAdd),
                FilteredRecipes = _recipeService.GetEntities(SortPredicate: (c) => c.DateOfAdd),
                filteredCategories = new string[0],
                search = null
            };



            return View(searchRecipe);
        }
        #endregion

    }
}

