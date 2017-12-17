$(function () {
    $("#upVote").click(function () {
        registerVote(true);
    });
    $("#downVote").click(function () {
        registerVote(false);
    });
});

function registerVote(isUpvote) {
    if (isUpvote) {
        $("#upVote").prop("disabled", true);
        $("#downVote").prop("disabled", false);
    }
    else {
        $("#upVote").prop("disabled", false);
        $("#downVote").prop("disabled", true);
    }

    var antiForgeryValue = $('[name="__RequestVerificationToken"]').val();
    var questionId = $("#itemId").val();

    var dataRaw = {
        questionId: questionId,
        isUpvote: `${isUpvote}`
    }

    //var data = JSON.stringify(dataRaw);

    var dataType = 'application/json; charset=utf-8';

    $.ajax({
        type: "POST",
        url: '/questions/vote',
        dataType: "json",
        data: dataRaw,
        contentType: dataType,
        headers: {
            Accept: "application/json",
            "RequestVerificationToken": antiForgeryValue,
            "QuestionId": questionId,
            "IsUpvote": isUpvote
        },
        success: function (data) {
            console.log("success" + data);
        },
        error: function (err) {
            console.log(err);
        }
    });
}