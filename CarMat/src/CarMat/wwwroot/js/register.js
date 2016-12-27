(function () {

    provinceSource = [];

    $.get("/api/Demographics/GetProvinces")
        .done(function (data) {
            provinceSource = data;
            $("#Province").autocomplete({
                source: provinceSource,
            });
        });

    function autocompleteLoad() {
        var input = document.getElementById('City');
        var countryRestrict = { 'country': 'pl' }; // only Poland
        var options = {
            types: ['(cities)'], // only Cities name
            componentRestrictions: countryRestrict
        };
        // documentation: developers.google.com/maps/documentation/javascript/reference#Autocomplete
        var autocomplete = new google.maps.places.Autocomplete(input, options);
    }

    google.maps.event.addDomListener(window, 'load', autocompleteLoad);

})();