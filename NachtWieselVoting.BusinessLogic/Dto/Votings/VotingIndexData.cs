using NachtWieselVoting.BusinessLogic.Dto.VotingOptions;
using System.ComponentModel;

namespace NachtWieselVoting.BusinessLogic.Dto.Votings;

public sealed class VotingIndexData
{
    [DisplayName("ИД")]
    public int Id { get; set; }
    [DisplayName("Название")]
    public string Name { get; set; } = null!;
    [DisplayName("Описание")]
    public string? Description { get; set; } = null!;
    public List<VotingOptionStatsData> Options { get; set; } = [];
}
