// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    var secondLoc = $("#secondLocation").val();
    var isPost = $("#isPost").val();
    if (!isPost) {
        $("#DestinationId").val(secondLoc);
    }
    var obiletCookie = $("#obiletCookie").val();
    if (obiletCookie) {
        var split = obiletCookie.split('-');
        if (split[0]) {
            $("#OrigionId").val(split[0]);
        }
        if (split[1]) {
            $("#DestinationId").val(split[1]);
        }
    }
    $("#OrigionId").select2();
    $("#DestinationId").select2();

    $('#todayButton').click(function () {
        ChangeDate("#todayButton", "#tomorrowButton");
    });
    $('#tomorrowButton').click(function () {
        ChangeDate("#tomorrowButton", "#todayButton");
    });
    $('#changeRoute').click(function () {
        var origin = $("#OrigionId").val();
        var destination = $("#DestinationId").val();
        $("#OrigionId").val(destination).change();
        $("#DestinationId").val(origin).change();
    });
});
function ChangeDate(first, second) {

    var date = new Date($('#DeparturaDate').val());
    var selectedDay = date.getDate();
    var selectedMonth = date.getMonth() + 1;
    var selectedYear = date.getFullYear();

    var now = new Date();
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var year = now.getFullYear();
    var today = year + "-" + (month) + "-" + (day);

    if (selectedDay !== day || selectedMonth !== month || selectedYear !== year) {
        if (first === "#tomorrowButton") {
            var next = new Date(now.getTime() + 24 * 60 * 60 * 1000);
            var day = ("0" + next.getDate()).slice(-2);
            var month = ("0" + (next.getMonth() + 1)).slice(-2);
            var tomorrow = next.getFullYear() + "-" + (month) + "-" + (day);
            $('#DeparturaDate').val(tomorrow);
        }
        else {
            $('#DeparturaDate').val(today);
        }
    }
    if (!$(first).hasClass("btn-secondary")) {
        $(first).addClass("btn-secondary")
        $(second).removeClass("btn-secondary")
        if (!$(second).hasClass("btn-outline-secondary"))
            $(second).addClass("btn-outline-secondary")
        if ($(first).hasClass("btn-outline-secondary"))
            $(first).removeClass("btn-outline-secondary")
    }

}
