$(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/Votes/Live").build();
    connection.on("Change", function (optionIds) {
        UpdateOptions(optionIds);
    });

    connection.start().then(function () {
        connection.invoke("Enter", VotingId).catch(function (err) {
            return console.error(err.toString());
        });
    });
});

function UpdateOptions(increaseIds) {
    TotalCount += optionIds.length;
    $('[signalr-updatable="true"]')
}