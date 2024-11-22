using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NachtWieselVoting.Web.Pages.VotingOptions;

[Authorize]
public class VotingOptionCreateModel : PageModel
{
    [BindProperty]
    public int VotingId { get; set; }
    [BindProperty]
    [DisplayName("������� �����")]
    [Required(ErrorMessage = "������� ������� �����!")]
    [MinLength(1, ErrorMessage = "������� ������� �����!")]
    [MaxLength(1000, ErrorMessage = "������������ ����� ������� ����� - {1} ��������!")]
    public string Name { get; set; } = null!;

    public void OnGet(int votingId)
    {
    }
}
