﻿(function () {

    $(".filters .page-header, .filters-horizontal .text-center").on("click", function () {
        $(".filters .filter-form, .filters-horizontal .filter-form").toggleClass("active");
        $(".filters .page-header i").toggleClass("fa-caret-right").toggleClass("fa-caret-left");
        $(".filters-horizontal h1 .fa-caret-down, .filters-horizontal h1 .fa-caret-left").toggleClass("fa-caret-down").toggleClass("fa-caret-left");
    });

})();