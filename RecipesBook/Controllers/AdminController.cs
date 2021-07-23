using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesBook.DataManagers;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDataManager<Category> _categoryService;
        private readonly IDataManager<Recipe> _recipeService;
        private readonly IDataManager<User> _userService;

        public AdminController(IDataManager<Category> categoriesService, IDataManager<Recipe> recipeService, IDataManager<User> userService)
        {
            _categoryService = categoriesService;
            _recipeService = recipeService;
            _userService = userService;
        }
        [Route("/admin/recipes")]
        public ActionResult Recipes()
        {
            return View();
        }
        [Route("/admin/categories")]
        public ActionResult Categories()
        {
            IEnumerable<Category> categories = _categoryService.GetEntities(SortPredicate: (x) => x.DateOfAdd);
            return View(categories);
        }
        
        public ActionResult SetHidden(string id, bool isHidden)
        {
            if (id != null)
            {
                var cat = _categoryService.Get(id);
                if (cat != null)
                {
                    cat.IsHidden = isHidden;
                    if (_categoryService.Edit(id, cat))
                    {
                        return Ok();
                    }
                }
            }
            return BadRequest();

        }
        [Route("/admin/users")]
        public ActionResult Users()
        {
            return View();
        }

    }
}
