using Microsoft.EntityFrameworkCore;
using NachtWieselVoting.BusinessLogic.Dto.VotingOptions;
using NachtWieselVoting.BusinessLogic.Dto.Votings;
using NachtWieselVoting.Data.Contexts;
using NachtWieselVoting.Data.Entities;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IVotingService
{
    Task<List<VotingListRowModel>> GetListAsync(int userId, bool mine);
    Task<VotingEditData?> FindEditDataAsync(int id);
    Task<VotingIndexData?> FindIndexDataAsync(int id, int viewerUserId);
    Task<VotingEntity?> FindAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task CreateAsync(VotingEntity entity);
    Task UpdateAsync(VotingEntity entity);
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
    public Task<VotingEditData?> FindEditDataAsync(int id)
        => context.Votings.Where(x => x.Id == id).Select(x => new VotingEditData()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            EndTime = x.EndTime,
            Multiple = x.Multiple,
        }).FirstOrDefaultAsync();

    public Task<VotingIndexData?> FindIndexDataAsync(int id, int viewerUserId)
        => context.Votings.Where(x => x.Id == id).Select(x => new VotingIndexData()
        {
            Id = x.Id,
            Name = x.Name,
            IsOwner = x.CreatorId == viewerUserId,
            Description = x.Description,
            EndTime = x.EndTime,
            Multiple = x.Multiple,
            Options = x.Options.OrderBy(y => y.Order).ThenBy(y => y.Id).Select(y => new VotingOptionStatsData()
            {
                Id = y.Id,
                Name = y.Name,
                VotedCount = y.Votes.Count,
                Checked = y.Votes.Any(z => z.UserId == viewerUserId)
            }).ToList()
        }).FirstOrDefaultAsync();

    public Task<VotingEntity?> FindAsync(int id)
        => context.Votings.FirstOrDefaultAsync(x => x.Id == id);

    public async Task CreateAsync(VotingEntity entity)
    {
        await context.Votings.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(VotingEntity entity)
    {
        context.Votings.Update(entity);
        await context.SaveChangesAsync();
    }
}
