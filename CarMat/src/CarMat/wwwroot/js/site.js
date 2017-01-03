// Write your Javascript code.

(function () {

    $(window).on("scroll", function () {
        if ($(document).scrollTop() > 50) {
            $('nav, .search-form').addClass("shrink");
        }
        else {
            $('nav, .search-form').removeClass("shrink");
        }
    });

    //fit text functions for most popular offers
    $(".top-vehicles li .bottom-description h2").each(function () {
        $(this).fitText(1.5);
    });

    $(".top-vehicles li .top-description h4").each(function () {
        $(this).fitText(1.9);
    });

    //function for resizing and proper fit of the most popular offers
    $(window).on("load resize", function () {

        var images = $(".top-vehicles li img");

        images.each(function () {
            $(this).css("height", "auto");
        });

        if (window.innerWidth > 1200) {
            var height = 0;

            images.each(function () {
                if ($(this).height() > height) {
                    height = $(this).height();
                }
            });

            images.each(function () {
                $(this).css("height", height);
            });
        }
    });
}());

