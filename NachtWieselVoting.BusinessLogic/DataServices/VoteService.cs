using Microsoft.EntityFrameworkCore;
using NachtWieselVoting.Data.Contexts;
using NachtWieselVoting.Data.Entities;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IVoteService
{
    Task<Tuple<List<int>, List<int>>> VoteAsync(int userId, List<int> optionIds);
}

public sealed class VoteService(NachtWieselVotingDbContext context) : IVoteService
{
    public async Task<Tuple<List<int>, List<int>>> VoteAsync(int userId, List<int> optionIds)
    {
        var options = await context.Options
            .Include(x => x.Voting)
            .Where(x => optionIds.Contains(x.Id))
            .ToListAsync();
        if (options.Count == 0 || !options.All(x => x.VotingId == options[0].VotingId))
        {
            return Tuple.Create<List<int>, List<int>>([], []);
        }
        var voting = options[0].Voting;
        if (!voting.Multiple && options.Count > 1)
        {
            return Tuple.Create<List<int>, List<int>>([], []);
        }

        var pastVotes = await context.Votes
            .Where(x => x.UserId == userId)
            .Where(x => x.Option.Voting.Id == voting.Id)
            .ToListAsync();

        var removeOptions = pastVotes.Where(x => !optionIds.Contains(x.OptionId)).ToList();
        var addOptions = options.Where(x => pastVotes.All(y => y.OptionId != x.Id)).ToList();

        context.Votes.RemoveRange(removeOptions);
        await context.Votes.AddRangeAsync(addOptions.Select(option => new VoteEntity()
        {
            Option = option,
            UserId = userId,
        }));
        await context.SaveChangesAsync();

        return Tuple.Create(pastVotes.Select(x => x.OptionId).ToList(), optionIds);
    }
}
