using System.ComponentModel.DataAnnotations;

namespace StudyPythonWebsite.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле 'Username' обязательно для заполнения.")]
        [StringLength(50, ErrorMessage = "Длина поля 'Username' должна быть от {2} до {1} символов.", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Поле 'Password' обязательно для заполнения.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Длина поля 'Password' должна быть от {2} до {1} символов.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Выберите роль.")]
        public string Role { get; set; } // Добавляем свойство Role для выбора роли при регистрации
    }
}
