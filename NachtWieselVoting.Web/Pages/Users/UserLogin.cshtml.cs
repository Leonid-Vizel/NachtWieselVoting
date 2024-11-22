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
    [DisplayName("�����")]
    [Required(ErrorMessage = "������� �����!")]
    [MinLength(1, ErrorMessage = "������� �����!")]
    [MaxLength(1000, ErrorMessage = "������������ ����� ������ - {1} ��������!")]
    public string Login { get; set; } = null!;
    [BindProperty]
    [DisplayName("������")]
    [Required(ErrorMessage = "������� ������!")]
    [MinLength(1, ErrorMessage = "������� ������!")]
    [DataType(DataType.Password, ErrorMessage = "������� ������!")]
    [MaxLength(100, ErrorMessage = "������������ ����� ������ - {1} ��������!")]
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
            ModelState.AddModelError(nameof(Password), "������������ ����� ��� ������!");
            return Page();
        }
        await userManager.SignInAsync(found);
        return Redirect("/");
    }
}
