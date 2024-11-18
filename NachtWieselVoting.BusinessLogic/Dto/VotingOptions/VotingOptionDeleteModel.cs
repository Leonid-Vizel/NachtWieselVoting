namespace NachtWieselVoting.BusinessLogic.Dto.VotingOptions;

public sealed class VotingOptionDeleteModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string VotingName { get; set; } = null!;
}
