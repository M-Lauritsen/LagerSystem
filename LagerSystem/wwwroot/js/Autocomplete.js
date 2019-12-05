$(document).ready(function () {
    $('#item').autocomplete({
        source: '/api/item/search'
    });
});