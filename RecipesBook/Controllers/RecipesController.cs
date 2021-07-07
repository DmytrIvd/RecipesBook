using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesBook.DataManagers;
using RecipesBook.Models;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
            return View(
               rec
                );
        }
        [Route("uploadRecipe")]
        [HttpPost]
        public IActionResult UploadRecipe(RecipeAddEditViewModel recipeAddEditViewModel)
        {
            if (recipeAddEditViewModel.MainImage != null)
            {
                byte[] image = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    recipeAddEditViewModel.MainImage.CopyTo(ms);
                    image = ms.ToArray();
                }

                recipeAddEditViewModel.RealImage = Convert.ToBase64String(image);
            }

            IList<Category> tags = new List<Category>();
            if (recipeAddEditViewModel.SelectedCategories != null)
            {
                tags = _categoryService.GetEntities(
                   (c) => recipeAddEditViewModel.SelectedCategories.Contains(c.ID), SortPredicate: c => c.ID);
                if (tags.Count == 0)
                {
                    ModelState.AddModelError("SelectedCategories", "Error");
                }
            }

            if (ModelState.IsValid)
            {


                var id = int.Parse(_recipeService.GetEntities(SortPredicate: c => c.Id).First().Id) + 1;
                Recipe recipe = new Recipe
                {
                    Id = id.ToString(),
                    Name = recipeAddEditViewModel.Name,
                    Categories = tags.ToArray(),
                    DateOfAdd = DateTime.Now,
                    Description = recipeAddEditViewModel.Description,
                    Ingredients = recipeAddEditViewModel.Ingredients,
                    MainImage = Convert.FromBase64String(recipeAddEditViewModel.RealImage),


                };
                _recipeService.Create(recipe);

                return Redirect($"recipes/{recipe.ID}");

            }
            recipeAddEditViewModel.AllCategories = _categoryService.GetEntities(SortPredicate: c => c.DateOfAdd);
            return View(recipeAddEditViewModel);


        }
        [Route("uploadRecipe")]
        [HttpGet]
        public IActionResult UploadRecipe()
        {
            RecipeAddEditViewModel recipeAddEditViewModel = new RecipeAddEditViewModel
            {
                AllCategories = _categoryService.GetEntities(SortPredicate: c => c.DateOfAdd),
                Steps=new StepAddEditViewModel[]
                {
                    new StepAddEditViewModel
                    {
                        Text="123",
                    },
                    new StepAddEditViewModel
                    {
                        Text="333"
                    }
                }
            };
            return View(recipeAddEditViewModel);
        }
        [Route("editRecipe/{recipe}")]
        [HttpGet]
        public IActionResult EditRecipe(string recipe)
        {
            var rec = _recipeService.Get(recipe, true);
            if (rec != null)
            {
                RecipeAddEditViewModel recipeAddEditViewModel = new RecipeAddEditViewModel
                {
                    AllCategories = _categoryService.GetEntities(SortPredicate: c => c.DateOfAdd),
                    SelectedCategories = new string[0],
                    Description = rec.Description,
                    Name = rec.Name,
                    Ingredients = rec.Ingredients,
                    RealImage = Convert.ToBase64String(rec.MainImage),
                };
                return View(recipeAddEditViewModel);
            }
            return View("Error", new ErrorViewModel() { Message = "It seems this recipe does not exist (yet or already)" });

        }
        [Route("editRecipe/{recipe}")]
        [HttpPost]
        public IActionResult EditRecipe(string recipe, RecipeAddEditViewModel recipeAddEditViewModel)
        {
            if (ModelState.IsValid)
            {

                return Redirect($"recipes/{recipe}");
            }
            return View(recipeAddEditViewModel);
        }
        [Route("deleteRecipe/{recipe}")]
        public IActionResult DeleteRecipe(string recipe)
        {
            if (_recipeService.Delete(recipe))
            {
                //Redirect to admin panel 
                //TODO
                return Redirect("/");
            }
            return View("Error", new ErrorViewModel() { Message = "It seems this category does not exist (yet or already)" });

        }
    }
}
