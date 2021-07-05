using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
    public class SearchRecipeViewModel
    {
        public IEnumerable<Category> AllCategories { get; set; }
        public string[] selectedCategories { get; set; }
        public string search { get; set; }
        public IEnumerable<Recipe> FilteredRecipes { get; set; }
    }
    public class SearchCategoryViewModel
    {
        public IEnumerable<Category> filteredCategories { get; set; }
        public string search { get; set; }
    }
}
