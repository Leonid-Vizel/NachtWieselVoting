using Microsoft.EntityFrameworkCore;
using NachtWieselVoting.Data.Contexts;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IVotingService
{
    Task<bool> ExistsAsync(int id);
}

public sealed class VotingService(NachtWieselVotingDbContext context) : IVotingService
{
    public Task<bool> ExistsAsync(int id)
        => context.Votings.AnyAsync(x => x.Id == id);
}
