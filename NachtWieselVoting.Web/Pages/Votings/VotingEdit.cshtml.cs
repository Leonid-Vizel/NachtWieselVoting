using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NachtWieselVoting.Web.Pages.Votings;

public class VotingEditModel : PageModel
{
    [BindProperty]
    public int Id { get; set; }
    [BindProperty]
    [DisplayName("��������")]
    [Required(ErrorMessage = "������� ��������!")]
    [MinLength(1, ErrorMessage = "������� ��������!")]
    [MaxLength(1000, ErrorMessage = "������������ ����� �������� - {1} ��������!")]
    public string Name { get; set; } = null!;

    public void OnGet(int id)
    {
    }
}
