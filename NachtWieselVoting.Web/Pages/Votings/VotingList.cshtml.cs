using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NachtWieselVoting.Web.Pages.Votings;

[Authorize]
public class VotingListModel : PageModel
{
    public void OnGet()
    {
    }
}
