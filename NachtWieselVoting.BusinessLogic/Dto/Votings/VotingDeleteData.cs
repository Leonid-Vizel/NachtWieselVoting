namespace NachtWieselVoting.BusinessLogic.Dto.Votings;

public sealed class VotingDeleteData
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int VoteCount { get; set; }
}
