using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NachtWieselVoting.BusinessLogic.DataServices;
using NachtWieselVoting.BusinessLogic.CommonServices;

namespace NachtWieselVoting.Web.Pages.Users;

public class UserLoginModel(IUserService userService, IUserManager userManager) : PageModel
{
    [BindProperty]
    [DisplayName("Логин")]
    [Required(ErrorMessage = "Укажите логин!")]
    [MinLength(1, ErrorMessage = "Укажите логин!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина логина - {1} символов!")]
    public string Login { get; set; } = null!;
    [BindProperty]
    [DisplayName("Пароль")]
    [Required(ErrorMessage = "Укажите пароль!")]
    [MinLength(1, ErrorMessage = "Укажите пароль!")]
    [DataType(DataType.Password, ErrorMessage = "Укажите пароль!")]
    [MaxLength(100, ErrorMessage = "Максимальная длина пароля - {1} символов!")]
    public string Password { get; set; } = null!;

    public void OnGet()
        => Page();

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var found = await userService.FindByLoginAndPasswordAsync(Login, Password);
        if (found == null)
        {
            ModelState.AddModelError(nameof(Password), "Некорректный логин или пароль!");
            return Page();
        }
        await userManager.SignInAsync(found);
        return Redirect("/");
    }
}
