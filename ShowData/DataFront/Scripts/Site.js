$(document).ready({

});

function showData()
{
    var color = $('#inputColorpicker1').val();
    var font = $('#fontSelect1').val();
    console.log(color);
    console.log(font);
    var dateRangeQuery = $('.get-data-form').serialize();
    console.log(dateRangeQuery);
    $.ajax({
        url: "http://localhost:25136/GetDataRecords" + dateRangeQuery,
        success(data) {
            console.log(data);
        },
        dataType: 'json'
    });
}