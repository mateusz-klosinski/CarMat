(function () {


    $(".js-watch").on("click", function (e)
    {
        var button = $(e.target);
        var offerId = button.attr("data-offerid");

        var done = function () {
            var text = (button.text() === "Obserwuj") ? "Obserwujesz" : "Obserwuj";

            button.toggleClass("btn-default");
            button.toggleClass("btn-success");
            button.text(text);
        };

        if (button.hasClass("btn-default"))
        {
            $.ajax({
                method: "POST",
                url: "/api/Offers/Watch/" + offerId
            })
            .done(done);
        }
        else
        {
            $.ajax({
                method: "POST",
                url: "/api/Offers/StopWatching/" + offerId
            })
            .done(done);
        }

    });


})();