﻿using System.ComponentModel;

namespace NachtWieselVoting.BusinessLogic.Dto.Votings;

public sealed class VotingListRowModel
{
    [DisplayName("ИД")]
    public int Id { get; set; }
    [DisplayName("Название")]
    public string Name { get; set; } = null!;
    [DisplayName("Кол-во опций")]
    public int OptionCount { get; set; }
    [DisplayName("Кол-во голосов")]
    public int VoteCount { get; set; }
}
