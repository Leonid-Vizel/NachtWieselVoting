using Microsoft.EntityFrameworkCore;
using NachtWieselVoting.BusinessLogic.Dto.Votings;
using NachtWieselVoting.Data.Contexts;
using NachtWieselVoting.Data.Entities;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IVotingService
{
    Task<List<VotingListRowModel>> GetListAsync(int userId, bool mine);
    Task<bool> ExistsAsync(int id);
    Task CreateAsync(VotingEntity entity);
}

public sealed class VotingService(NachtWieselVotingDbContext context) : IVotingService
{
    public Task<List<VotingListRowModel>> GetListAsync(int userId, bool mine)
    {
        var query = context.Votings.AsNoTracking();

        if (mine)
        {
            query = query.Where(x => x.CreatorId == userId);
        }
        else
        {
            query = query.Where(x => x.EndTime == null || x.EndTime >= DateTime.Now)
                .Where(x => x.Options.Count > 0);
        }

        return query.Select(x => new VotingListRowModel()
            {
                Id = x.Id,
                Name = x.Name,
                OptionCount = x.Options.Count,
                VoteCount = x.Options.Sum(y => y.Votes.Count)
            }).OrderBy(x => x.Name)
            .ThenBy(x => x.Id)
            .ToListAsync();
    }

    public Task<bool> ExistsAsync(int id)
        => context.Votings.AnyAsync(x => x.Id == id);

    public async Task CreateAsync(VotingEntity entity)
    {
        await context.Votings.AddAsync(entity);
        await context.SaveChangesAsync();
    }
}
