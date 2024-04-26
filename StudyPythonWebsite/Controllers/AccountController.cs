using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyPythonWebsite.Models;
using StudyPythonWebsite.DataContext;
using StudyPythonWebsite.ViewModels;

namespace StudyPythonWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly StudyPythonWebsiteContext _context;

        public AccountController(StudyPythonWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    
                    if (user.Role == "Student")
                    {
                        return RedirectToAction("IndexStudent", "Topic");
                    }
                    else if (user.Role == "Teacher")
                    {
                        return RedirectToAction("IndexTeacher", "Exercise");
                    }
                    else if (user.Role == "Admin")
                    {
                        return RedirectToAction("IndexAdmin", "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "User with this username already exists");
                    return View(model);
                }

                var newUser = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role // Используем выбранную роль из модели
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(model);
        }
    }
}
