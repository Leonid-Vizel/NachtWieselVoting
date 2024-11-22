using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NachtWieselVoting.BusinessLogic.DataServices;

namespace NachtWieselVoting.Web.Pages.Users;

public class UserRegisterModel(IUserService userService) : PageModel
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
    
    [BindProperty]
    [DisplayName("��������� ������")]
    [Required(ErrorMessage = "��������� ������!")]
    [DataType(DataType.Password, ErrorMessage = "��������� ������!")]
    [Compare(nameof(Password), ErrorMessage = "������ �� ���������!")]
    public string PasswordConfirmation { get; set; } = null!;

    public void OnGet()
        => Page();

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await userService.RegitserAsync(Login, Password);
        return Redirect("/Login");
    }
}
