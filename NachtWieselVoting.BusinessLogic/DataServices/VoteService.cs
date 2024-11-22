using Microsoft.EntityFrameworkCore;
using NachtWieselVoting.Data.Contexts;
using NachtWieselVoting.Data.Entities;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IVoteService
{
    Task<int?> VoteAsync(int userId, int[] optionIds);
}

public sealed class VoteService(NachtWieselVotingDbContext context) : IVoteService
{
    public async Task<int?> VoteAsync(int userId, int[] optionIds)
    {
        var options = await context.Options
            .Include(x => x.Voting)
            .Where(x => optionIds.Distinct().Contains(x.Id))
            .ToListAsync();
        if (options.Count == 0 || !options.All(x => x.VotingId == options[0].VotingId))
        {
            return null;
        }
        var voting = options[0].Voting;
        if (!voting.Multiple && options.Count > 1)
        {
            return null;
        }
        var voteAlreadyExists = await context.Votes.AnyAsync(x=>x.UserId == userId && x.Option.Voting.Id == voting.Id);
        if (voteAlreadyExists)
        {
            return null;
        }

        await context.Votes.AddRangeAsync(options.Select(option => new VoteEntity()
        {
            Option = option,
            UserId = userId,
        }));

        return voting.Id;
    }
}
