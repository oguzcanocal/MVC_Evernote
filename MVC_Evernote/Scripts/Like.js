﻿$(function () {

    var noteids = [];

    $("div[data-note-id]").each(function (i, e) {

        noteids.push($(e).data("note-id"));
    });

    $.ajax({

        method: "POST",
        url: "/Note/GetLiked",
        data: { ids: noteids }
    }).done(function (data) {

        if (data.result != null) {

            for (var i = 0; i < 10; i++) {
                var id = data.result[i];
                var likedNote = $("div[data-note-id=" + id + "]");
                var btn = likedNote.find("button[data-liked]");
                var span = btn.find("span.like-star");
                btn.attr("data-liked", true);
                span.removeClass("glyphicon-star-empty");
                span.addClass("glyphicon-star");


            }
        }

    }).fail(function () {

    })

    $("button[data-liked]").click(function () {

        var btn = $(this);
        var liked = btn.data("liked");
        var noteid = btn.data("note-id");
        var spanStar = btn.find("span.like-star");
        var spanCount = btn.find("span.like-count");

        console.log(liked);
        console.log("likecount: " + spanCount.text());

        $.ajax({
            method: "POST",
            url: "/Note/SetLikeState",
            data: { "noteid": noteid, "liked": !liked }
        }).done(function (data) {
            console.log(data);

            if (data.hasError) {
                alert(data.errorMessage);
            } else {
                liked = !liked;
                btn.attr("data-liked", true);
                spanCount.text(data.result);
                console.log("likecount-after: " + spanCount.text());

                spanStar.removeClass("glyphicon-star-empty");
                spanStar.removeClass("glyphicon-star");

                if (liked) {
                    spanStar.addClass("glyphicon-star");
                } else {
                    spanStar.addClass("glyphicon-star-empty");
                }
            }
        }).fail(function () {
            alert("Sunucu ile bağlantı kurulamadı.");
        })


    });

});