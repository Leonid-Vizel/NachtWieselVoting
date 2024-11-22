using System.ComponentModel;

namespace NachtWieselVoting.BusinessLogic.Dto.Votings;

public sealed class VotingIndexModel
{
    [DisplayName("ИД")]
    public int Id { get; set; }
    [DisplayName("Название")]
    public string Name { get; set; } = null!;
}
