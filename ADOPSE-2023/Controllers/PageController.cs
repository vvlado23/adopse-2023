using Microsoft.AspNetCore.Mvc;
using ADOPSE_2023.Models;

namespace ADOPSE_2023.Controllers
{
    public class PageController : Controller
    {
        private readonly Search _search;

        public PageController()
        {
            // Instantiate the Search class or inject it using dependency injection
            _search = new Search();
        }

    
      

        [HttpPost]
        public IActionResult GetCourses(int pNum)
        {
            var courses = Search.instance.SearchDocuments("", pNum);

            if (courses == null)
            {
                courses = new List<Module>();
            }

            return PartialView("_CourseItems", courses);
        }

        [HttpPost]
        public IActionResult UpdatePageNum(int pNum)
        {
            // Perform any necessary actions to update the page number
            // This could involve saving the page number in a database or session

            // Return a success response
            return Ok();
        }
    }
}