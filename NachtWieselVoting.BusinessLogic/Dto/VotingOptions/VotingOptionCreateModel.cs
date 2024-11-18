using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NachtWieselVoting.BusinessLogic.Dto.VotingOptions;

public sealed class VotingOptionCreateModel
{
    public int VotingId { get; set; }
    [DisplayName("Надпись опции")]
    [Required(ErrorMessage = "Укажите надпись опции!")]
    [MinLength(1, ErrorMessage = "Укажите надпись опции!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина надписи опции - {1} символов!")]
    public string Name { get; set; } = null!;
}
