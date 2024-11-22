using NachtWieselVoting.Data.Contexts;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IVoteService
{

}

public sealed class VoteService(NachtWieselVotingDbContext context) : IVoteService
{

}
