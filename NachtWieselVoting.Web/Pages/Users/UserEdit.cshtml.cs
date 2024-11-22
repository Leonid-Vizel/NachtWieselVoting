using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NachtWieselVoting.BusinessLogic.CommonServices;
using NachtWieselVoting.BusinessLogic.DataServices;

namespace NachtWieselVoting.Web.Pages.Users;

[Authorize]
public class UserEditModel(IUserService userService, IUserManager userManager) : PageModel
{
    [BindProperty]
    [DisplayName("�����")]
    [Required(ErrorMessage = "������� �����!")]
    [MinLength(1, ErrorMessage = "������� �����!")]
    [MaxLength(1000, ErrorMessage = "������������ ����� ������ - {1} ��������!")]
    public string Login { get; set; } = null!;
    [BindProperty]
    [DisplayName("���")]
    [Required(ErrorMessage = "������� ���!")]
    [MinLength(1, ErrorMessage = "������� ���!")]
    [MaxLength(1000, ErrorMessage = "������������ ����� ����� - {1} ��������!")]
    public string Name { get; set; } = null!;

    public async Task<IActionResult> OnGet()
    {
        var userId = userManager.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }
        var found = await userService.FindProfileAsync(userId.Value);
        if (found == null)
        {
            return NotFound();
        }
        Login = found.Login;
        Name = found.Name;
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var userId = userManager.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }
        var found = await userService.FindAsync(userId.Value);
        if (found == null)
        {
            return NotFound();
        }
        found.Login = Login;
        found.Name = Name;
        await userService.UpdateAsync(found);
        return Redirect("/Profile");
    }
}
