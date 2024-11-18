using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NachtWieselVoting.BusinessLogic.Dto.Users;

public sealed class UserRegisterModel : UserModifyModel
{
    [DisplayName("Пароль")]
    [Required(ErrorMessage = "Укажите пароль!")]
    [MinLength(1, ErrorMessage = "Укажите пароль!")]
    [DataType(DataType.Password, ErrorMessage = "Укажите пароль!")]
    [MaxLength(100, ErrorMessage = "Максимальная длина пароля - {1} символов!")]
    public string Password { get; set; } = null!;
}
