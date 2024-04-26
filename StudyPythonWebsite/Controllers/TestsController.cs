using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StudyPythonWebsite.Controllers
{
    public class TestsController : Controller
    {
        public IActionResult Index()
        {
            // В зависимости от роли пользователя, определяем доступ к странице упражнений
            if (User.IsInRole("Student"))
            {
                // Для студента доступ только на чтение
                return RedirectToAction("IndexReadOnly", "Exercise");
            }
            else if (User.IsInRole("Teacher"))
            {
                // Для преподавателя доступ на чтение и проверку упражнений
                return RedirectToAction("IndexTeacher", "Exercise");
            }
            else if (User.IsInRole("Admin"))
            {
                // Для администратора доступ на чтение и изменение упражнений
                return RedirectToAction("IndexAdmin", "Exercise");
            }
            else
            {
                // В остальных случаях перенаправляем на страницу входа
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
