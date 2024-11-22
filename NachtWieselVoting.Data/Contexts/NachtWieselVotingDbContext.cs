using Microsoft.EntityFrameworkCore;
using NachtWieselVoting.Data.Entities;

namespace NachtWieselVoting.Data.Contexts;

public sealed class NachtWieselVotingDbContext : DbContext
{
    public NachtWieselVotingDbContext(DbContextOptions<NachtWieselVotingDbContext> options) : base(options) { }

    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<VotingEntity> Votings { get; set; } = null!;
    public DbSet<VoteEntity> Votes { get; set; } = null!;
    public DbSet<VotingOptionEntity> Options { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().Property(x => x.Password).HasConversion(
            x => BCrypt.Net.BCrypt.HashPassword(x),
            x => x);

        base.OnModelCreating(modelBuilder);
    }
}
