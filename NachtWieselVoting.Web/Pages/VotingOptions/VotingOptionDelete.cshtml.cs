using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NachtWieselVoting.BusinessLogic.DataServices;

namespace NachtWieselVoting.Web.Pages.VotingOptions;

[Authorize]
public class VotingOptionDeleteModel : PageModel
{
    [BindProperty]
    public int Id { get; set; }
    public int VotingId { get; set; }
    public string Name { get; set; } = null!;

    private readonly IVotingOptionService _optionService;
    public VotingOptionDeleteModel(IVotingOptionService optionService)
    {
        _optionService = optionService;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var found = await _optionService.FindAsync(id);
        if (found == null)
        {
            return NotFound();
        }
        VotingId = found.VotingId;
        Name = found.Name;
        return Page();
    }

    public async Task<IActionResult> OnPost(int id)
    {
        var found = await _optionService.FindAsync(id);
        if (found == null)
        {
            return NotFound();
        }
        await _optionService.DeleteAsync(found);
        return Redirect($"/Voting/{found.VotingId}");
    }
}
