using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace NachtWieselVoting.Web.Pages.VotingOptions;

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