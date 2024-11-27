namespace NachtWieselVoting.BusinessLogic.Dto.Votings;

public sealed class VotingEditData
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? EndTime { get; set; }
    public bool Multiple { get; set; }
}
