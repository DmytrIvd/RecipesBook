using Microsoft.AspNetCore.Mvc;
using RecipesBook.DataManagers;
using RecipesBook.Models;
using RecipesBook.Models.Entities;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            //var img= Convert.ToBase64String(cat.MainImage);
            for (int i = 0; i < cat.Recipes.Length; i++)
            {
                cat.Recipes[i] = _recipeService.Get(cat.Recipes[i].ID);
            }
            return View("/Views/Category/ViewCategory.cshtml",
              cat); ;
        }


        [HttpPost]
        [Route("createCategory")]
        public IActionResult CreateCategory(Category category, IFormFile image)
        {
            if (ModelState.IsValid && image != null)
            {

                using (MemoryStream ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    category.MainImage = ms.ToArray();
                }
                //Just stupid
                var id = int.Parse(_categoryService.GetEntities(SortPredicate: c => c.Id).First().Id) + 1;
                category.Id = id.ToString();
                category.DateOfAdd = DateTime.Now;
                category.Recipes = new Recipe[0];
                _categoryService.Create(category);
                return Redirect($"category/{category.ID}");
            }
            if (image == null)
            {
                ModelState.AddModelError("MainImage", "Property cannot be null");
            }
            return View();
        }
        [HttpGet]
        [Route("createCategory")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("editCategory/{category}")]
        public IActionResult EditCategory([FromForm] Category category, [FromForm] IFormFile image, [FromForm] string Recipes, [FromForm] string MainImage)
        {
            if (ModelState.IsValid)
            {

                category.Recipes = JsonConvert.DeserializeObject<Recipe[]>(Recipes);
                if (MainImage != null)
                    category.MainImage = (byte[])JsonConvert.DeserializeObject(MainImage);
                if (image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.CopyTo(ms);
                        category.MainImage = ms.ToArray();
                    }
                }

                if (_categoryService.Edit(category.ID, category))
                {
                    return Redirect($"/category/{category.ID}");
                }
                else
                {
                    ModelState.AddModelError("", "Cannot save changes, try again later");
                }

            }
            if (image == null)
            {
                ModelState.AddModelError("MainImage", "Property cannot be null");
            }
            return View(category);
        }
        [HttpGet]
        [Route("editCategory/{category}")]
        public IActionResult EditCategory(string category)
        {
            var cat = _categoryService.Get(category);
            if (cat == null)
            {
                Response.StatusCode = 404;
                return View("Error", new ErrorViewModel() { Message = "It seems this category does not exist (yet or already)" });

            }
            return View(cat);
        }


        [Route("deleteCategory/{category}")]
        public IActionResult DeleteCategory(string category)
        {
            if (_categoryService.Delete(category))
            {
                ViewBag.Messsage = "Record Delete Successfully";
                return Redirect("/");
            }
            return View("Error", new ErrorViewModel() { Message = "It seems this category does not exist (yet or already)" });

        }
    }
}
