using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NachtWieselVoting.BusinessLogic.CommonServices;
using NachtWieselVoting.BusinessLogic.DataServices;
using NachtWieselVoting.BusinessLogic.Dto.Users;

namespace NachtWieselVoting.Web.Pages.Users;

[Authorize]
public class UserProfileModel(IUserService userService, IUserManager userManager) : PageModel
{
    public UserProfileData Data { get; set; } = null!;
    public async Task<IActionResult> OnGet()
    {
        var userId = userManager.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }
        var found = await userService.FindProfileAsync(userId.Value);
        if (found == null)
        {
            return NotFound();
        }
        Data = found;
        return Page();
    }
}
