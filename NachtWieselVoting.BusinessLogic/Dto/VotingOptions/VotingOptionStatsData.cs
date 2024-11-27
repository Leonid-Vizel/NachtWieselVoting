using System.ComponentModel;

namespace NachtWieselVoting.BusinessLogic.Dto.VotingOptions;

public sealed class VotingOptionStatsData
{
    public int Id { get; set; }
    [DisplayName("Опция")]
    public string Name { get; set; } = null!;
    public int VotedCount { get; set; }
    public bool Checked { get; set; }
}
