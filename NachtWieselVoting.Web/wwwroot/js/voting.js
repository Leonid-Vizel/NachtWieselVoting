$(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/Votes/Live").build();
    connection.on("Change", UpdateOptions);

    connection.start().then(function () {
        connection.invoke("Enter", VotingId).catch(function (err) {
            return console.error(err.toString());
        });
    });
});

function UpdateOptions(oldOptionIds, updateOptionIds) {
    TotalCount = TotalCount - oldOptionIds.length + updateOptionIds.length;
    if (TotalCount < 0) {
        TotalCount = 0;
    }
    $('[signalr-tag="total"]').text(`Всего голосов: ${TotalCount}`);
    $('[signalr-updatable="true"]').each(function () {
        var optionId = parseInt($(this).attr("signalr-optionId"));
        var votedCount = parseInt($(this).attr("signalr-votedCount"));
        if (oldOptionIds.includes(optionId)) {
            votedCount = votedCount - 1;
        }
        if (updateOptionIds.includes(optionId)) {
            votedCount = votedCount + 1;
        }
        if (votedCount < 0) {
            votedCount = 0;
        }
        $(this).attr("signalr-votedCount", votedCount);
        var percent = TotalCount == 0 ? 0 : (votedCount / TotalCount * 100);
        $(this).find("p > span").text(`(${votedCount} голосов)`);
        $(this).find("div.progress").attr("aria-valuenow", votedCount).attr("aria-valuemax", TotalCount);
        $(this).find("div.progress-bar").attr("style", `width: ${percent}%`);
    });
}