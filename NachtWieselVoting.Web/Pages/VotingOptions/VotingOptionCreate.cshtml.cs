using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NachtWieselVoting.Web.Pages.VotingOptions;

[Authorize]
public class VotingOptionCreateModel : PageModel
{
    [BindProperty]
    public int VotingId { get; set; }
    [BindProperty]
    [DisplayName("Надпись опции")]
    [Required(ErrorMessage = "Укажите надпись опции!")]
    [MinLength(1, ErrorMessage = "Укажите надпись опции!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина надписи опции - {1} символов!")]
    public string Name { get; set; } = null!;

    public void OnGet(int votingId)
    {
    }
}
