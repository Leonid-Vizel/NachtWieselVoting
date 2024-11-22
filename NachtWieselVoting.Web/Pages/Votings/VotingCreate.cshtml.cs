using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NachtWieselVoting.BusinessLogic.CommonServices;
using NachtWieselVoting.BusinessLogic.DataServices;
using NachtWieselVoting.Data.Entities;

namespace NachtWieselVoting.Web.Pages.Votings;

[Authorize]
public class VotingCreateModel(IUserManager userManager, IVotingService votingService) : PageModel
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

    public IActionResult OnGet()
        => Page();

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var userId = userManager.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }
        var entity = new VotingEntity()
        {
            Name = Name,
            Description = Description,
            CreatorId = userId.Value,
            EndTime = EndTime,
            Multiple = Multiple
        };
        await votingService.CreateAsync(entity);
        return Redirect("/Votings?Mine=true");
    }
}
