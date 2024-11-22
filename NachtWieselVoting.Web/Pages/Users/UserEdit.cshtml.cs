using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace NachtWieselVoting.Web.Pages.Users;

public class UserEditModel : PageModel
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

    public void OnGet()
    {
    }

    public void OnPost()
    {
    }
}
