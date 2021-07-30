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
            var rec = _recipeService.Get(recipe);
            if (rec == null)
            {
                Response.StatusCode = 404;
                return View("Error", new ErrorViewModel() { Message = "It seems this recipe does not exist (yet or already)" });
            }
            return View(
               rec
                );
        }
        //To do: Add auth check
        [Route("createStep")]
        [HttpGet]
        public IActionResult CreateStep()
        {

            return PartialView("EditorTemplates/_stepEdit", new StepAddEditViewModel());
        }
        //To do: Add auth check
        [Route("deleteStep/{step}")]
        public IActionResult DeleteStep(string step)
        {
            if (_stepService.Delete(step))
            {
                Response.StatusCode = 200;
            }
            Response.StatusCode = 404;
            return Ok();
        }
        //To do: Add auth check
        #region Upload recipe
        private string loadBase64(IFormFile fromFile)
        {
            byte[] image = null;
            using (MemoryStream ms = new MemoryStream())
            {
                fromFile.CopyTo(ms);
                image = ms.ToArray();
            }
            return Convert.ToBase64String(image);
        }
        [Route("uploadRecipe")]
        [HttpPost]
        public IActionResult UploadRecipe(RecipeAddEditViewModel recipeAddEditViewModel)
        {

            if (recipeAddEditViewModel.MainImage != null)
            {

                try
                {
                    recipeAddEditViewModel.RealImage = loadBase64(recipeAddEditViewModel.MainImage);
                }
                catch (ArgumentNullException)
                {
                    ModelState.AddModelError("SelectedImage", "File is damaged");
                }
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


            if (recipeAddEditViewModel.Steps != null)
            {
                for (int i = 0; i < recipeAddEditViewModel.Steps.Length; i++)
                {
                    if (recipeAddEditViewModel.Steps[i].SelectedImg != null)
                    {
                        try
                        {

                            recipeAddEditViewModel.Steps[i].RealImg = loadBase64(recipeAddEditViewModel.Steps[i].SelectedImg);
                        }
                        catch (ArgumentNullException)
                        {
                            ModelState.AddModelError($"Steps[{i}].SelectedImg", "File is damaged");
                        }
                    }
                }

            }

            if (ModelState.IsValid)
            {

                Recipe recipe = new Recipe
                {
                    Name = recipeAddEditViewModel.Name,

                    DateOfAdd = DateTime.Now,
                    Description = recipeAddEditViewModel.Description,
                    Ingredients = recipeAddEditViewModel.Ingredients,
                    MainImage = Convert.FromBase64String(recipeAddEditViewModel.RealImage),
                    Steps = recipeAddEditViewModel.Steps.Select(sAEvm => new Step { Img = Convert.FromBase64String(sAEvm.RealImg), Text = sAEvm.Text }).ToArray()

                };
                recipe.Categories = tags.Select(t => new CategoryRecipe { Category = t, Recipe = recipe }).ToArray();
                _recipeService.Create(recipe);

                return Redirect($"/recipes/{recipe.ID}");

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
                AllCategories = _categoryService.GetEntities(SortPredicate: c => c.DateOfAdd)

            };
            return View(recipeAddEditViewModel);
        }
        #endregion
        //To do: Add auth check
        #region Edit recipe
        [Route("editRecipe/{recipe}")]
        [HttpGet]
        public IActionResult EditRecipe(string recipe)
        {
            var rec = _recipeService.Get(recipe);
            if (rec != null)
            {
                RecipeAddEditViewModel recipeAddEditViewModel = new RecipeAddEditViewModel
                {
                    Id = rec.Id,
                    AllCategories = _categoryService.GetEntities(SortPredicate: c => c.DateOfAdd),
                    SelectedCategories = rec.Categories.Select(cr => cr.CategoryId).ToArray(),
                    Description = rec.Description,
                    Name = rec.Name,
                    Ingredients = rec.Ingredients,
                    RealImage = Convert.ToBase64String(rec.MainImage),
                    Steps = rec.Steps.Select(s => new StepAddEditViewModel
                    {
                        Id = s.Id,
                        RealImg = Convert.ToBase64String(s.Img),
                        Text = s.Text
                    }).ToArray()
                };
                return View(recipeAddEditViewModel);
            }
            return View("Error", new ErrorViewModel() { Message = "It seems this recipe does not exist (yet or already)" });

        }


        [Route("editRecipe/{recipe}")]
        [HttpPost]
        public IActionResult EditRecipe(string recipe, RecipeAddEditViewModel recipeAddEditViewModel)
        {
            if (recipeAddEditViewModel.MainImage != null)
            {

                try
                {
                    recipeAddEditViewModel.RealImage = loadBase64(recipeAddEditViewModel.MainImage);
                }
                catch (ArgumentNullException)
                {
                    ModelState.AddModelError("SelectedImage", "File is damaged");
                }
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


            if (recipeAddEditViewModel.Steps != null)
            {
                for (int i = 0; i < recipeAddEditViewModel.Steps.Length; i++)
                {
                    if (recipeAddEditViewModel.Steps[i].SelectedImg != null)
                    {
                        try
                        {

                            recipeAddEditViewModel.Steps[i].RealImg = loadBase64(recipeAddEditViewModel.Steps[i].SelectedImg);
                        }
                        catch (ArgumentNullException)
                        {
                            ModelState.AddModelError($"Steps[{i}].SelectedImg", "File is damaged");
                        }
                    }
                }

            }
            if (ModelState.IsValid)
            {



                Recipe editedRecipe = new Recipe
                {
                    Id = recipeAddEditViewModel.Id,
                    Name = recipeAddEditViewModel.Name,

                    DateOfAdd = DateTime.Now,
                    Description = recipeAddEditViewModel.Description,
                    Ingredients = recipeAddEditViewModel.Ingredients,
                    MainImage = Convert.FromBase64String(recipeAddEditViewModel.RealImage),
                    Steps = recipeAddEditViewModel.Steps.Select(sAEvm => new Step { Id = sAEvm.Id, Img = Convert.FromBase64String(sAEvm.RealImg), Text = sAEvm.Text }).ToArray()

                };
                editedRecipe.Categories = tags.Select(t => new CategoryRecipe { CategoryId = t.Id, RecipeId = editedRecipe.Id }).ToArray();
                //add steps
                if (_recipeService.Edit(editedRecipe.Id, editedRecipe))
                {

                    return Redirect($"/recipes/{recipe}");
                }
            }
            recipeAddEditViewModel.AllCategories = _categoryService.GetEntities(SortPredicate: c => c.DateOfAdd);
            return View(recipeAddEditViewModel);
        }
        #endregion
        //To do: Add auth check
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
