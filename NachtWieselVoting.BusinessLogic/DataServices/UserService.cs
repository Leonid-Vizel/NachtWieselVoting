using NachtWieselVoting.Data.Contexts;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IUserService
{

}

public sealed class UserService(NachtWieselVotingDbContext context) : IUserService
{
}
