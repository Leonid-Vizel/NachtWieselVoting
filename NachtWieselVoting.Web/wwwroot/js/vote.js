var signalRConnection;
$(function () {
    $("#vote-button").prop("disabled", true);
    signalRConnection = new signalR.HubConnectionBuilder().withUrl("/Votes/Live").build();
    signalRConnection.start().then(function () {
        $("#vote-button").prop("disabled", false);
    });
})

function GetChecked() {
    var checked = [];
    $.each($('input[name="vote-inputs"]:checked'), function () {
        checked.push(parseInt($(this).val()));
    });
    return checked;
}

function SendVote() {
    let checkedIds = GetChecked();
    signalRConnection.invoke("Vote", VotingId, checkedIds).then(function () {
        window.location.href = `/Voting/${VotingId}`;
    });
}