﻿namespace NachtWieselVoting.BusinessLogic.Dto.Votings;

public sealed class VotingDeleteModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int VoteCount { get; set; }
}
