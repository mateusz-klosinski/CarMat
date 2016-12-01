(function () {

    modelSource = [];
    brandSource = [];

    $.get("/api/GetBrands").done(function (data) {
        brandSource = data;
        $("#vehicle-brand").autocomplete({
            source: brandSource,
            select: brandSelected
        });
    });

    var brandSelected = function (event ,ui) {
        $(this).val(ui.item.value);
        $.get("/api/GetModels/" + $(this).val()).done(function (data) {
            modelSource = data;
            $("#vehicle-model").autocomplete({
                source: modelSource
            });
        });
    };

})();