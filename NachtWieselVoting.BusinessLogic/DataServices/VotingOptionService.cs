using Microsoft.EntityFrameworkCore;
using NachtWieselVoting.Data.Contexts;
using NachtWieselVoting.Data.Entities;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IVotingOptionService
{
    Task<int> GetMaxOrderAsync(int votingId);
    Task<VotingOptionEntity?> FindAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task CreateAsync(VotingOptionEntity option);
    Task DeleteAsync(VotingOptionEntity option);
}

public sealed class VotingOptionService(NachtWieselVotingDbContext context) : IVotingOptionService
{
    public Task<int> GetMaxOrderAsync(int votingId)
        => context.Options
        .Where(x => x.VotingId == votingId)
        .Select(x => x.Order)
        .OrderByDescending(x => x)
        .FirstOrDefaultAsync();

    public Task<VotingOptionEntity?> FindAsync(int id)
        => context.Options.FirstOrDefaultAsync(x => x.Id == id);

    public Task<bool> ExistsAsync(int id)
        => context.Options.AnyAsync(x => x.Id == id);

    public async Task CreateAsync(VotingOptionEntity option)
    {
        await context.Options.AddAsync(option);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(VotingOptionEntity option)
    {
        context.Options.Remove(option);
        await context.SaveChangesAsync();
    }
}
