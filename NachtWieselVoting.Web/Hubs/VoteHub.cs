using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using NachtWieselVoting.BusinessLogic.CommonServices;
using NachtWieselVoting.BusinessLogic.DataServices;

namespace NachtWieselVoting.Web.Hubs;

public sealed class VoteHub : Hub
{
    private static readonly string VotingPrefix = "VOTING";
    private static readonly string ChangeMethod = "Change";
    private readonly IVoteService _voteService;
    private readonly IVotingService _votingService;
    private readonly IUserManager _userManager;

    public VoteHub(IVoteService voteService, IVotingService votingService, IUserManager userManager)
    {
        _voteService = voteService;
        _votingService = votingService;
        _userManager = userManager;
    }

    [Authorize]
    public async Task Enter(int votingId)
    {
        if (!await _votingService.ExistsAsync(votingId))
        {
            return;
        }
        await Groups.AddToGroupAsync(Context.ConnectionId, $"{VotingPrefix}-{votingId}");
    }

    [Authorize]
    public async Task Vote(int votingId, List<int> optionIds)
    {
        optionIds = optionIds.Distinct().ToList();
        var userId = _userManager.GetUserId();
        if (userId == null)
        {
            return;
        }
        var results = await _voteService.VoteAsync(userId.Value, optionIds);
        await Clients.Group($"{VotingPrefix}-{votingId}").SendAsync(ChangeMethod, results.Item1, results.Item2);
    }
}
