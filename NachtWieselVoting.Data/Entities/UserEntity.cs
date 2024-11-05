using System.ComponentModel.DataAnnotations;

namespace NachtWieselVoting.Data.Entities;

public sealed class UserEntity
{
    public int Id { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(1000)]
    public string Name { get; set; } = null!;
    [Required]
    [MinLength(1)]
    [MaxLength(1000)]
    public string Login { get; set; } = null!;
    [Required]
    [MinLength(1)]
    [MaxLength(1000)]
    public string Password { get; set; } = null!;
    public List<VoteEntity> Votes { get; set; } = [];
}
