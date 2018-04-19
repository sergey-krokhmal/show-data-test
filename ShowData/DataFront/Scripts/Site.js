$(document).ready(()=>{
    loadFromCoockie();
});

function showData()
{
    var color = $('#inputColorpicker1').val();
    var font = $('#fontSelect1').val();
    
    var dateFrom = $('#dateFromPicker1').val();
    var momentDateFrom = moment(dateFrom + ' 00:00:00', "DD.MM.YYYY HH:mm:ss");
    momentDateFrom.utc();

    var dateTo = $('#dateToPicker1').val();
    var momentDateTo = moment(dateTo + ' 23:59:59', "DD.MM.YYYY HH:mm:ss");
    momentDateTo.utc();

    saveToCoockies(color, font, dateFrom, dateTo);

    var query = $('.get-data-form').serialize();
    $.ajax({
        url: 'http://localhost:25136/DataService.svc/GetDataRecords',
        data: { "from": "15.04.2018 00:00:00", "to":"20.04.2018 00:00:00"},
        success: function (data) { console.log(data)},
        dataType: 'json'
    });
}

function saveToCoockies(color, font, dateFrom, dateTo) {
    var exp = 1;
    $.cookie('text_color', color, {
        expires: exp
    });
    $.cookie('text_font', font, {
        expires: exp
    });
    $.cookie('date_from', dateFrom, {
        expires: exp
    });
    $.cookie('date_to', dateTo, {
        expires: exp
    });
}

function loadFromCoockie() {
    var color = $.cookie('text_color');
    if (color !== undefined) {
        $('#inputColorpicker1').val(color);
    }
    var font = $.cookie('text_font');
    if (font !== undefined) {
        $('#fontSelect1').val(font);
    }
    var dateFrom = $.cookie('date_from');
    if (dateFrom !== undefined) {
        $('#dateFromPicker1').val(dateFrom);
    }
    var dateTo = $.cookie('date_to')
    if (dateTo !== undefined) {
        $('#dateToPicker1').val(dateTo);
    }
}