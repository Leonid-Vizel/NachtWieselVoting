using System.ComponentModel;

namespace NachtWieselVoting.BusinessLogic.Dto.Users;

public sealed class UserProfileData
{
    [DisplayName("Логин")]
    public string Login { get; set; } = null!;
    [DisplayName("Имя")]
    public string Name { get; set; } = null!;
}
