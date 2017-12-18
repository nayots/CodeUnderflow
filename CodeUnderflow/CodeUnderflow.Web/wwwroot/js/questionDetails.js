$(function () {
    $("#answerText").keyup(function () {
        verifyAnswer();
    });
    $("#submitAnswer").prop("disabled", true);
    $("#answerTextWarning").hide();
});

function verifyAnswer() {
    var answerText = $("#answerText").val();
    if (answerText.length < 2 || answerText.length > 300) {
        $("#submitAnswer").prop("disabled", true);
        $("#answerText").val(answerText.substr(0, 300));
        $("#answerTextWarning").show();
        return false;
    }
    else {
        $("#submitAnswer").prop("disabled", false);
        $("#answerTextWarning").hide();
        return true;
    }
}

//$(function () {
//    $("#star").click(function () {
//        registerVote();
//    });
//});

//function registerVote(isUpvote) {

//    var isStared = $("#star").hasClass("far");

//    if (isUpvote) {
//        $("#upVote").prop("disabled", true);
//        $("#downVote").prop("disabled", false);
//    }
//    else {
//        $("#upVote").prop("disabled", false);
//        $("#downVote").prop("disabled", true);
//    }

//    var antiForgeryValue = $('[name="__RequestVerificationToken"]').val();
//    var questionId = $("#itemId").val();

//    var dataRaw = {
//        questionId: questionId
//    }

//    var data = JSON.stringify(dataRaw);

//    var dataType = 'application/json; charset=utf-8';

//    $.ajax({
//        type: "POST",
//        url: '/questions/vote',
//        dataType: "json",
//        data: data,
//        contentType: dataType,
//        headers: {
//            Accept: "application/json",
//            "RequestVerificationToken": antiForgeryValue,
//            "QuestionId": questionId
//        },
//        success: function (data) {
//            console.log("success" + data);
//        },
//        error: function (err) {
//            console.log(err);
//        }
//    });
//}