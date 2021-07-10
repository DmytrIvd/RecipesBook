using Microsoft.AspNetCore.Http;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Models
{
    public class RecipeAddEditViewModel
    {
        public string Id { get; set; }
        [DisplayName("Recipe name")]
        [Required(ErrorMessage = "Please enter recipe name")]
        [MinLength(3, ErrorMessage = "The name is too small!")]
        [MaxLength(20, ErrorMessage = "Too long name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter recipe description")]
        [DisplayName("Recipe description")]
        [MaxLength(200, ErrorMessage = "Too long description")]
        public string Description { get; set; }


        public IEnumerable<Category> AllCategories { get; set; }

        [Required(ErrorMessage = "Please add category tags so people can find your recipe quicker")]
        [DisplayName("Categories")]
        [MinLength(1, ErrorMessage = "Add some more tags please")]
        public string[] SelectedCategories { get; set; }

       
       

        [Required(ErrorMessage = "Add some ingredients please!")]
        [MinLength(2, ErrorMessage = "How to cook with one ingredient?")]
        [MaxLength(50, ErrorMessage = "Please reduce the amount of ingredients to a minimum. If this is not a magic potion? Right?..")]
        public string[] Ingredients { get; set; }
        //????????
        [Required(ErrorMessage = "Add some steps please!")]
        [MinLength(1, ErrorMessage = "Add some steps please")]
        [MaxLength(20, ErrorMessage = "Tooo many steps")]

        public StepAddEditViewModel[] Steps { get; set; }

        public IFormFile MainImage { get; set; }
        public string RealImage { get;  set; }
    }
}
