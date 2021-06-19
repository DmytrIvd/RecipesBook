using Microsoft.AspNetCore.Mvc;
using RecipesBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("category/{category}")]
        public IActionResult ViewCategory([FromRoute] string category)
        {
            return View("/Views/Category/ViewCategory.cshtml",
                new CategoryViewModel()
                {
                    Name = "Category" + category,
                    Description = "Description" + category,
                    Id = category,
                    Recipes = new RecipeViewModel[]
                    {
                        new RecipeViewModel(){Name="Recipe1",Id="1" },
                        new RecipeViewModel(){Name="Recipe2",Id="2" },
                        new RecipeViewModel(){Name="Recipe3",Id="3" },
                    }
                });
        }
    }
}
