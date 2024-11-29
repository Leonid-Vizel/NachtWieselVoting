using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NachtWieselVoting.BusinessLogic.CommonServices;
using NachtWieselVoting.BusinessLogic.DataServices;
using NachtWieselVoting.BusinessLogic.Dto.Votings;

namespace NachtWieselVoting.Web.Pages.Votings;

public sealed class VotingVoteModel : PageModel
{
    public VotingIndexData Data { get; set; } = null!;

    private readonly IVotingService _votingService;
    private readonly IUserManager _userManager;
    public VotingVoteModel(IVotingService votingService, IUserManager userManager)
    {
        _votingService = votingService;
        _userManager = userManager;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var userId = _userManager.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }
        var data = await _votingService.FindIndexDataAsync(id, userId.Value);
        if (data == null)
        {
            return NotFound();
        }
        Data = data;
        return Page();
    }
}
