using Microsoft.AspNetCore.Mvc;

namespace ADOPSE_2023.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult TeacherInfo()
        {
            ViewBag.Title = "Teacher Info"; //title passed to infoTest.cshtml
            return View();
        }

        public IActionResult InfoTest()
        {
            ViewBag.Title = "Courses Info"; //title passed to infoTest.cshtml
            return View();
        }  

        public IActionResult CoursesPage()
        {
            return View();
        }

        public IActionResult CalendarPage()
        {
            return View();
        }

    }
}

