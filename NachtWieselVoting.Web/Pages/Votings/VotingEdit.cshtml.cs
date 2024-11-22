using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NachtWieselVoting.Web.Pages.Votings;

public class VotingEditModel : PageModel
{
    [BindProperty]
    public int Id { get; set; }
    [BindProperty]
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    [MinLength(1, ErrorMessage = "Укажите название!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина названия - {1} символов!")]
    public string Name { get; set; } = null!;

    public void OnGet(int id)
    {
    }
}
