using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NachtWieselVoting.Web.Pages.Users;

[Authorize]
public class UserDeleteModel : PageModel
{
    public void OnGet()
    {
    }

    public void OnPost()
    {
    }
}
