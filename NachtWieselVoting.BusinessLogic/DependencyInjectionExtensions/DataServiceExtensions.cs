using Microsoft.Extensions.DependencyInjection;
using NachtWieselVoting.BusinessLogic.DataServices;

namespace NachtWieselVoting.BusinessLogic.DependencyInjectionExtensions;

public static class DataServiceExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IVotingService, VotingService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IVotingOptionService, VotingOptionService>()
            .AddScoped<IVoteService, VoteService>();
    }
}
