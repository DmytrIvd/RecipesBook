using Microsoft.AspNetCore.Http;
using RecipesBook.Models.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecipesBook.Models
{
    public class CategoryAddEditViewModel
    {
        //Only for edit!
        public string Id { get; set; }


        [DisplayName("Category name")]
        [Required(ErrorMessage = "Please enter category name")]
        [MinLength(3, ErrorMessage = "The name is too small!")]
        [MaxLength(20, ErrorMessage = "Too long name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter category description")]
        [DisplayName("Category description")]
        [MaxLength(30, ErrorMessage = "Too long description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Select image please")]
        public IFormFile MainImage { get; set; }

       
        public byte[] RealImage { get; set; }

    }
}
