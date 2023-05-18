using Microsoft.AspNetCore.Mvc;

namespace ADOPSE_2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult RegisterPage()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            Search search = new Search();
            search.searchTerm();
            return View();
        }
    }
}
