using System.ComponentModel.DataAnnotations;

namespace NachtWieselVoting.Data.Entities;

public sealed class VotingEntity
{
    [Key]
    public int Id { get; set; }
    public int CreatorId { get; set; }
    public UserEntity Creator { get; set; } = null!;
    [Required]
    [MinLength(1)]
    [MaxLength(1000)]
    public string Name { get; set; } = null!;
    [MaxLength(10000)]
    public string? Description { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool Multiple { get; set; }
    public List<VotingOptionEntity> Options { get; set; } = [];
}
