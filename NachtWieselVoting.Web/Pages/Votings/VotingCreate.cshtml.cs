using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NachtWieselVoting.Web.Pages.Votings;

[Authorize]
public class VotingCreateModel : PageModel
{
    [BindProperty]
    [DisplayName("��������")]
    [Required(ErrorMessage = "������� ��������!")]
    [MinLength(1, ErrorMessage = "������� ��������!")]
    [MaxLength(1000, ErrorMessage = "������������ ����� �������� - {1} ��������!")]
    public string Name { get; set; } = null!;
    public void OnGet()
    {
    }
}
