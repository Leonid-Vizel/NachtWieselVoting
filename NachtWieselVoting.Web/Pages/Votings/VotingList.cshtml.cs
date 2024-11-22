using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NachtWieselVoting.BusinessLogic.CommonServices;
using NachtWieselVoting.BusinessLogic.DataServices;
using NachtWieselVoting.BusinessLogic.Dto.Votings;

namespace NachtWieselVoting.Web.Pages.Votings;

[Authorize]
public class VotingListModel(IVotingService votingService, IUserManager userManager) : PageModel
{
    public List<VotingListRowModel> List { get; set; } = [];
    public async Task<IActionResult> OnGet(bool mine = false)
    {
        var userId = userManager.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }
        List = await votingService.GetListAsync(userId.Value, mine);
        return Page();
    }
}
