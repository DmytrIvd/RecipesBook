using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignIn()
        {
            //To do :/
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
