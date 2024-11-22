using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace NachtWieselVoting.Web.Pages.Users;

public class UserRegisterModel : PageModel
{
    [BindProperty]
    [DisplayName("Логин")]
    [Required(ErrorMessage = "Укажите логин!")]
    [MinLength(1, ErrorMessage = "Укажите логин!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина логина - {1} символов!")]
    public string Login { get; set; } = null!;
    
    [BindProperty]
    [DisplayName("Имя")]
    [Required(ErrorMessage = "Укажите имя!")]
    [MinLength(1, ErrorMessage = "Укажите имя!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина имени - {1} символов!")]
    public string Name { get; set; } = null!;
    
    [BindProperty]
    [DisplayName("Пароль")]
    [Required(ErrorMessage = "Укажите пароль!")]
    [MinLength(1, ErrorMessage = "Укажите пароль!")]
    [DataType(DataType.Password, ErrorMessage = "Укажите пароль!")]
    [MaxLength(100, ErrorMessage = "Максимальная длина пароля - {1} символов!")]
    public string Password { get; set; } = null!;
    
    [BindProperty]
    [DisplayName("Повторите пароль")]
    [Required(ErrorMessage = "Повторите пароль!")]
    [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают!")]
    public string PasswordConfirmation { get; set; } = null!;

    public void OnGet()
    {
    }

    public void OnPost()
    {
    }
}
