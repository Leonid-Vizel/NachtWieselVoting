using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NachtWieselVoting.BusinessLogic.Dto.Users;

public abstract class UserModifyModel
{
    [DisplayName("Логин")]
    [Required(ErrorMessage = "Укажите логин!")]
    [MinLength(1, ErrorMessage = "Укажите логин!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина логина - {1} символов!")]
    public string Login { get; set; } = null!;
    [DisplayName("Имя")]
    [Required(ErrorMessage = "Укажите имя!")]
    [MinLength(1, ErrorMessage = "Укажите имя!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина имени - {1} символов!")]
    public string Name { get; set; } = null!;
}
