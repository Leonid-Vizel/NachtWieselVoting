using NachtWieselVoting.Data.Contexts;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IVotingOptionService
{

}

public sealed class VotingOptionService(NachtWieselVotingDbContext context) : IVotingOptionService
{

}
