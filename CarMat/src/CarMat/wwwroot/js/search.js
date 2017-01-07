(function () {

    $(".js-search-term").on("input", function () {
        var searchAnchor = $(".js-search");
        var href = searchAnchor.attr("href");
        
        if (href.indexOf("?query=") == -1)
        {
            href += "?query="
        }
        else
        {
            var position = href.indexOf("=") + 1;
            href = href.substr(0, position) + $(this).val();

        }

        searchAnchor.attr("href", href);
    });

    $(".js-search-term").keypress(function (e) {
        if (e.which == 13) {
            location.href = $(".js-search").attr("href");
        }
    });
})();