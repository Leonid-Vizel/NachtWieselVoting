using Microsoft.AspNetCore.SignalR;

namespace NachtWieselVoting.Web.Hubs;

public sealed class VoteHub : Hub
{
    public async Task Vote(int option)
    {

    }
}
