using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace NachtWieselVoting.Web.Pages.Users;

public class UserLoginModel : PageModel
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
    {
    }
}
