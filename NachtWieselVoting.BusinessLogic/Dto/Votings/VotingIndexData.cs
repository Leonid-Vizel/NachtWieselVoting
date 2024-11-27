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
    public bool IsOwner { get; set; }
    public DateTime? EndTime { get; set; }
    public bool Multiple { get; set; }
    public List<VotingOptionStatsData> Options { get; set; } = [];
    public int TotalCount => Options.Sum(x => x.VotedCount);
}
