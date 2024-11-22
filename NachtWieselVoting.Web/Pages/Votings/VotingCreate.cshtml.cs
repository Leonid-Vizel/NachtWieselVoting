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
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    [MinLength(1, ErrorMessage = "Укажите название!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина названия - {1} символов!")]
    public string Name { get; set; } = null!;
    [BindProperty]
    [DisplayName("Описание")]
    [MaxLength(10000, ErrorMessage = "Максимальная длина описания - {1} символов!")]
    public string? Description { get; set; }
    [BindProperty]
    [DisplayName("Время окончания голосования (если применимо)")]
    public DateTime? EndTime { get; set; }
    [BindProperty]
    [DisplayName("Разрешить выбирать больше 1 опции")]
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
