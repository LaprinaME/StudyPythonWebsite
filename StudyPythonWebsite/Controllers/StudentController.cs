using Microsoft.AspNetCore.Mvc;

namespace StudyPythonWebsite.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            // Здесь можно реализовать логику для страницы студента
            return View();
        }
    }
}
