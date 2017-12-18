$(function () {
    $("input#autocomplete").keyup(function () {
        populateAutocomplete();
    })
});

function populateAutocomplete() {
    let searchValue = $("#autocomplete").val();
    let searchResults = [];

    if (searchValue.length >= 2) {
        $.get(`http://localhost:52303/search/query?searchTerm=${encodeURIComponent(searchValue)}`, function (data) {
            searchResults = data;
            console.log(data);
        });
    }

    $("#autocomplete").autocomplete({
        minLength: 2,
        source: function (request, response) {
            response($.map(searchResults, function (object, key) {
                console.log(object);
                //console.log(key);
                return {
                    label: object.title,
                    value: object.title,
                    url: object.url
                }
            }));
        }
        ,
        select: function (event, ui) {
            console.log(ui.item.url);
            window.location = window.location + `questions/details/${ui.item.url}`;
        }
    });
}