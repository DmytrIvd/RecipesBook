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
    public class CategoryController : Controller
    {
        private readonly IDataManager<Category> _categoryService;

        public CategoryController(IDataManager<Category> categories)
        {
            _categoryService = categories;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("category/{category}")]
        public IActionResult ViewCategory([FromRoute] string category)
        {
            return View("/Views/Category/ViewCategory.cshtml",
                new Category()
                {
                    Name = "Category" + category,
                    Description = "Description" + category,
                    Id = category,
                    Recipes = new Recipe[]
                    {
                        new Recipe(){Name="Recipe1",Id="1" },
                        new Recipe(){Name="Recipe2",Id="2" },
                        new Recipe(){Name="Recipe3",Id="3" },
                    }
                });
        }
    }
}
