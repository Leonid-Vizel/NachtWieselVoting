using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NachtWieselVoting.Web.Pages.Votings;

public class VotingDeleteModel : PageModel
{
    [BindProperty]
    public int Id { get; set; }
    public void OnGet(int id)
    {
    }
}