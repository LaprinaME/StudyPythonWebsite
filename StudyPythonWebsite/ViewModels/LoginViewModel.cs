using System.ComponentModel.DataAnnotations;

namespace StudyPythonWebsite.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите имя пользователя")]
        [Display(Name = "Имя пользователя")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
