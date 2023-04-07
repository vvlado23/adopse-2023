using LoginRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginRegister.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }


    }
}