using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NachtWieselVoting.Web.Pages.Votings;

[Authorize]
public class VotingIndexModel : PageModel
{
    public void OnGet(int id)
    {
    }
}
