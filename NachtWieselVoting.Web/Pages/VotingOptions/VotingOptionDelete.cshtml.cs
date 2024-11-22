using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NachtWieselVoting.Web.Pages.VotingOptions;

[Authorize]
public class VotingOptionDeleteModel : PageModel
{
    [BindProperty]
    public int Id { get; set; }
    public void OnGet(int id)
    {
    }
}
