using Microsoft.AspNetCore.Mvc;
using StudyPythonWebsite.Models;
using StudyPythonWebsite.DataContext;
using System.Linq;
using StudyPythonWebsite.ViewModels;

namespace StudyPythonWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudyPythonWebsiteContext _context;

        public HomeController(StudyPythonWebsiteContext context)
        {
            _context = context;
        }

        // GET: Отображение формы для входа пользователя
        public IActionResult Index()
        {
            return View();
        }

        // POST: Обработка входа пользователя
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Поиск пользователя по введенному логину и паролю в базе данных
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    // Успешная аутентификация
                    // Определяем, на какую страницу перенаправить пользователя в зависимости от его роли
                    string redirectPage;
                    switch (user.Role)
                    {
                        case "Student":
                            redirectPage = "IndexStudent";
                            break;
                        case "Teacher":
                            redirectPage = "IndexTeacher";
                            break;
                        case "Admin":
                            redirectPage = "IndexAdmin";
                            break;
                        default:
                            redirectPage = "Index"; // По умолчанию
                            break;
                    }

                    // Перенаправляем пользователя на соответствующую страницу
                    return RedirectToAction(redirectPage);
                }

                // Неверные учетные данные
                ViewBag.ErrorMessage = "Неправильный логин или пароль.";
            }

            // Если модель недействительна, возвращаем пользователя на ту же страницу с формой ввода
            return View("Index", model);
        }

    }
}