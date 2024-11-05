using System.ComponentModel.DataAnnotations;

namespace NachtWieselVoting.Data.Entities;

public sealed class VoteEntity
{
    [Key]
    public int Id { get; set; }
    public int VotingId { get; set; }
    public VotingEntity Voting { get; set; } = null!;
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
}
