using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NachtWieselVoting.Web.Pages.VotingOptions;

public class VotingOptionDeleteModel : PageModel
{
    [BindProperty]
    public int Id { get; set; }
    public void OnGet(int id)
    {
    }
}
