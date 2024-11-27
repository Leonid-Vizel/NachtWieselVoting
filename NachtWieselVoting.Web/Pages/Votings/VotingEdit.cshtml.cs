using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using NachtWieselVoting.BusinessLogic.DataServices;

namespace NachtWieselVoting.Web.Pages.Votings;

[Authorize]
public class VotingEditModel : PageModel
{
    [BindProperty]
    [DisplayName("��������")]
    [Required(ErrorMessage = "������� ��������!")]
    [MinLength(1, ErrorMessage = "������� ��������!")]
    [MaxLength(1000, ErrorMessage = "������������ ����� �������� - {1} ��������!")]
    public string Name { get; set; } = null!;
    [BindProperty]
    [DisplayName("��������")]
    [MaxLength(10000, ErrorMessage = "������������ ����� �������� - {1} ��������!")]
    public string? Description { get; set; }
    [BindProperty]
    [DisplayName("����� ��������� ����������� (���� ���������)")]
    public DateTime? EndTime { get; set; }
    [BindProperty]
    [DisplayName("��������� �������� ������ 1 �����")]
    public bool Multiple { get; set; }


    private readonly IVotingService _votingService;
    public VotingEditModel(IVotingService votingService)
    {
        _votingService = votingService;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var data = await _votingService.FindEditDataAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        Name = data.Name;
        Description = data.Description;
        EndTime = data.EndTime;
        Multiple = data.Multiple;
        return Page();
    }

    public async Task<IActionResult> OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var data = await _votingService.FindAsync(id);
        if (data == null)
        {
            return NotFound();
        }

        data.Name = Name;
        data.Description = Description;
        data.EndTime = EndTime;
        data.Multiple = Multiple;

        await _votingService.UpdateAsync(data);

        return Redirect("/");
    }
}
