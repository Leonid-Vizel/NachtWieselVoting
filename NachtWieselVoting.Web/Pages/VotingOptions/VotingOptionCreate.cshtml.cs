using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NachtWieselVoting.BusinessLogic.DataServices;
using NachtWieselVoting.Data.Entities;

namespace NachtWieselVoting.Web.Pages.VotingOptions;

[Authorize]
public class VotingOptionCreateModel : PageModel
{
    public int VotingId { get; set; }
    [BindProperty]
    [DisplayName("Надпись опции")]
    [Required(ErrorMessage = "Укажите надпись опции!")]
    [MinLength(1, ErrorMessage = "Укажите надпись опции!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина надписи опции - {1} символов!")]
    public string Name { get; set; } = null!;

    private readonly IVotingService _votingService;
    private readonly IVotingOptionService _optionService;
    public VotingOptionCreateModel(IVotingService votingService, IVotingOptionService optionService)
    {
        _votingService = votingService;
        _optionService = optionService;
    }

    public async Task<IActionResult> OnGet(int votingId)
    {
        VotingId = votingId;
        if (!await _votingService.ExistsAsync(votingId))
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPost(int votingId)
    {
        VotingId = votingId;
        if (!ModelState.IsValid)
        {
            return Page();
        }
        if (!await _votingService.ExistsAsync(votingId))
        {
            return NotFound();
        }
        var option = new VotingOptionEntity()
        {
            VotingId = votingId,
            Name = Name,
            Order = await _optionService.GetMaxOrderAsync(votingId) + 1,
        };
        await _optionService.CreateAsync(option);
        return Redirect($"/Voting/{votingId}");
    }
}
