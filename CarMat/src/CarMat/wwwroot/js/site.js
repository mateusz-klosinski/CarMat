// Write your Javascript code.

(function () {

    $(".top-vehicles li .bottom-description h2").each(function () {
        $(this).fitText(1.5);
    });

    $(".top-vehicles li .top-description h4").each(function () {
        $(this).fitText(1.9);
    });

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

