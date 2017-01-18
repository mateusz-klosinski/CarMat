(function () {

    var initialFinishHref;
    var initialDeleteHref;

    $(window).on("load", function () {
        initialFinishHref = $("#finish-modal a.btn.btn-danger").attr("href");
        initialDeleteHref = $("#delete-modal a.btn.btn-danger").attr("href");
    });

    $('#finish-modal').on('shown.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var offerid = button.data('offerid');

        var anchor = $("a.btn.btn-danger");
        var href = initialFinishHref;
        
        href += "/" + offerid;
        anchor.attr("href", href);
    });


    $('#delete-modal').on('shown.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var offerid = button.data('offerid');

        var anchor = $("a.btn.btn-danger");
        var href = initialDeleteHref;

        href += "/" + offerid;
        anchor.attr("href", href);
    });

})();