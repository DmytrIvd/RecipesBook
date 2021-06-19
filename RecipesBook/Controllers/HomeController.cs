using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipesBook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("")]
        [Route("Home")]
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("[controller]/[action]")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("[controller]/[action]")]
        public IActionResult About()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
