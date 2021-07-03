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
            return View(cat);
        }
        #region Create category
        [HttpPost]
        [Route("createCategory")]
        public IActionResult CreateCategory(CategoryAddEditViewModel categoryView)
        {
            //if (image != null)
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        image.CopyTo(ms);
            //        category.MainImage = ms.ToArray();
            //    }
            //}

            if (ModelState.IsValid)
            {

                //Just stupid
                var id = int.Parse(_categoryService.GetEntities(SortPredicate: c => c.Id).First().Id) + 1;

                Category category = new Category()
                {
                    Id = id.ToString(),
                    DateOfAdd = DateTime.Now,
                    Recipes = new Recipe[0],
                    Name = categoryView.Name,
                    Description = categoryView.Description
                };
                using (MemoryStream ms = new MemoryStream())
                {
                    categoryView.MainImage.CopyTo(ms);
                    category.MainImage = ms.ToArray();
                }

                _categoryService.Create(category);
                return Redirect($"category/{category.ID}");
            }

            return View(categoryView);
        }
        [HttpGet]
        [Route("createCategory")]
        public IActionResult CreateCategory()
        {
            return View();
        }
        #endregion
        #region Edit category
        [HttpPost]
        [Route("editCategory/{id}")]
        public IActionResult EditCategory(string id, CategoryAddEditViewModel categoryView)
        {
            if (ModelState.IsValid)
            {
                var original = _categoryService.Get(id);
                Category editedCategory = new Category
                {
                    Name = categoryView.Name,
                    Description = categoryView.Description,
                    DateOfAdd = original.DateOfAdd,
                    Recipes = original.Recipes
                };

                //if (MainImage != null)
                //    category.MainImage = (byte[])JsonConvert.DeserializeObject(MainImage);
                if (categoryView.MainImage != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        categoryView.MainImage.CopyTo(ms);
                        editedCategory.MainImage = ms.ToArray();
                    }
                }

                if (_categoryService.Edit(id, editedCategory))
                {
                    return Redirect($"category/{id}");
                }
                ModelState.AddModelError("", "Cannot save changes, try again later");


            }

            return View(categoryView);
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
            CategoryAddEditViewModel categoryAddEditViewModel = new CategoryAddEditViewModel()
            {
                Id = cat.Id,
                Name = cat.Name,
                Description = cat.Description,
                RealImage = cat.MainImage
            };
            return View(categoryAddEditViewModel);
        }
        #endregion
        #region delete category
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
        #endregion
    }
}
