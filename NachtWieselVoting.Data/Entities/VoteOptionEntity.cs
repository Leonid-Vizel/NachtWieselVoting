using System.ComponentModel.DataAnnotations;

namespace NachtWieselVoting.Data.Entities;

public sealed class VoteOptionEntity
{
    [Key]
    public int Id { get; set; }
    public int VotingId { get; set; }
    public VotingEntity Voting { get; set; } = null!;
    [Required]
    [MinLength(1)]
    [MaxLength(1000)]
    public string Name { get; set; } = null!;
    public List<VoteEntity> Votes { get; set; } = [];
}
