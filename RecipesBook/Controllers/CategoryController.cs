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
            var cat = _categoryService.Get(category);
            //Category is exists and not hidden
            if (cat != null && !cat.IsHidden)
            {

                //var img= Convert.ToBase64String(cat.MainImage);
               
                return View(cat);

            }


            Response.StatusCode = 404;
            return View("Error", new ErrorViewModel() { Message = "It seems this category does not exist (yet or already)" });
        }
        //To do: Add auth check
        #region Create category
        [HttpPost]
        [Route("createCategory")]
        public IActionResult CreateCategory(CategoryAddEditViewModel categoryView)
        {
            if (categoryView.MainImage != null)
            {
                byte[] image = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    categoryView.MainImage.CopyTo(ms);
                    image = ms.ToArray();
                }
                categoryView.RealImage = Convert.ToBase64String(image);
            }


            if (ModelState.IsValid)
            {

                
               

                Category category = new Category()
                {
                    
                    DateOfAdd = DateTime.Now,
                    Recipes = new CategoryRecipe[0],
                    Name = categoryView.Name,
                    Description = categoryView.Description,
                    MainImage = Convert.FromBase64String(categoryView.RealImage),
                    IsHidden = false
                };


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
        //To do: Add auth check
        #region Edit category
        [HttpPost]
        [Route("editCategory/{id}")]
        public IActionResult EditCategory(string id, CategoryAddEditViewModel categoryView)
        {
            if (categoryView.MainImage != null)
            {
                byte[] image = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    categoryView.MainImage.CopyTo(ms);
                    image = ms.ToArray();
                }
                categoryView.RealImage = Convert.ToBase64String(image);
            }
            if (ModelState.IsValid)
            {
                var original = _categoryService.Get(id);
                Category editedCategory = new Category
                {
                    Id = original.Id,
                    Name = categoryView.Name,
                    Description = categoryView.Description,
                    DateOfAdd = original.DateOfAdd,
                    Recipes = original.Recipes,
                    MainImage = Convert.FromBase64String(categoryView.RealImage),
                    IsHidden = original.IsHidden

                };

                if (_categoryService.Edit(id, editedCategory))
                {
                    //Editor is admin
                    if (editedCategory.IsHidden)
                        return Redirect($"/admin/categories");
                    return Redirect($"/category/{id}");
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
            //To do check if user is logged and if 
            // category is hidden show hidden category only if a user is admin
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
                RealImage = Convert.ToBase64String(cat.MainImage)
            };
            return View(categoryAddEditViewModel);


        }
        #endregion
        //To do: Add auth check
        #region delete category
        [Route("deleteCategory/{category}")]
        public IActionResult DeleteCategory(string category)
        {
            if (_categoryService.Delete(category))
            {
                ViewBag.Messsage = "Record Delete Successfully";
                //To admin page
                //TODO
                return Redirect("/");
            }
            return View("Error", new ErrorViewModel() { Message = "It seems this category does not exist (yet or already)" });

        }
        #endregion
    }
}
