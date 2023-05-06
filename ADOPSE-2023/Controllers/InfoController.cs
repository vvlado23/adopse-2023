using Microsoft.AspNetCore.Mvc;

namespace ADOPSE_2023.Controllers
{
    public class InfoController : Controller
    {

        public IActionResult InfoPage()
        {
            return View();
        }

        public IActionResult TeacherInfo()
        {
            return View();
        }

    }
}

