using NachtWieselVoting.Data.Contexts;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IVotingService
{

}

public sealed class VotingService(NachtWieselVotingDbContext context) : IVotingService
{

}
