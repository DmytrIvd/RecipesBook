using System.ComponentModel.DataAnnotations;

namespace RecipesBook.Models
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm a password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords is not matching")]
        public string ConfirmPassword { get; set; }
    }
}
