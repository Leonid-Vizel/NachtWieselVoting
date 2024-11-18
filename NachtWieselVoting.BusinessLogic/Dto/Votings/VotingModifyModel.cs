using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NachtWieselVoting.BusinessLogic.Dto.Votings;

public abstract class VotingModifyModel
{
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    [MinLength(1, ErrorMessage = "Укажите название!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина названия - {1} символов!")]
    public string Name { get; set; } = null!;
}
